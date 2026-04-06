using Microsoft.AspNetCore.Mvc;
using HealthcareMVC.Models;
using System.Text.Json;

namespace HealthcareMVC.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public AppointmentsController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var userRole = HttpContext.Session.GetString("UserRole");

            if (userId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Route based on user role
            if (userRole == "Doctor")
            {
                return await DoctorAppointments(userId);
            }
            else if (userRole == "Patient")
            {
                return await MyAppointments();
            }
            else if (userRole == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> DoctorAppointments(int userId)
        {
            try
            {
                // Get the doctor ID for this user from the API
                var doctorResponse = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors/byuser/{userId}");
                if (!doctorResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to get doctor info for userId {userId}");
                    ViewBag.Error = "Could not find doctor information";
                    ViewBag.UserRole = "Doctor";
                    return View("DoctorAppointments", new List<AppointmentViewModel>());
                }

                var doctorContent = await doctorResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Doctor Info Response: {doctorContent}");
                
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var doctorResult = JsonSerializer.Deserialize<JsonElement>(doctorContent, options);
                
                int doctorId = 0;
                if (doctorResult.TryGetProperty("data", out var doctorData) && doctorData.TryGetProperty("doctorId", out var docIdProp))
                {
                    doctorId = docIdProp.GetInt32();
                    Console.WriteLine($"Found doctorId {doctorId} for userId {userId}");
                }
                else
                {
                    Console.WriteLine("Could not extract doctorId from API response");
                    ViewBag.Error = "Could not find doctor information";
                    ViewBag.UserRole = "Doctor";
                    return View("DoctorAppointments", new List<AppointmentViewModel>());
                }

                // Now fetch appointments for this doctor
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/appointments/doctor/{doctorId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Doctor Appointments API Response: {responseContent}");
                    
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    
                    if (result.TryGetProperty("data", out var dataProperty))
                    {
                        var appointmentsJson = dataProperty.GetRawText();
                        Console.WriteLine($"Doctor Appointments JSON: {appointmentsJson}");
                        
                        try
                        {
                            var appointments = JsonSerializer.Deserialize<List<AppointmentViewModel>>(appointmentsJson, options);
                            Console.WriteLine($"Deserialized {appointments?.Count ?? 0} doctor appointments");
                            ViewBag.UserRole = "Doctor";
                            return View("DoctorAppointments", appointments ?? new List<AppointmentViewModel>());
                        }
                        catch (JsonException jsonEx)
                        {
                            Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
                            ViewBag.Error = $"Error parsing appointments: {jsonEx.Message}";
                        }
                    }
                    else
                    {
                        Console.WriteLine("'data' property not found in API response");
                        ViewBag.Error = "Invalid API response format";
                    }
                }
                else
                {
                    Console.WriteLine($"API returned status: {response.StatusCode}");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error: {errorContent}");
                    ViewBag.Error = "Failed to load appointments";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                ViewBag.Error = "Unable to connect to the server";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading doctor appointments: {ex.Message}\n{ex.StackTrace}");
                ViewBag.Error = $"Error loading appointments: {ex.Message}";
            }

            ViewBag.UserRole = "Doctor";
            return View("DoctorAppointments", new List<AppointmentViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Book(int doctorId)
        {
            if (doctorId <= 0)
            {
                return RedirectToAction("Index", "Doctors");
            }

            var model = new CreateAppointmentViewModel 
            { 
                DoctorId = doctorId,
                DoctorName = "Doctor",
                DoctorDepartment = "General",
                ConsultationFee = "₹500"
            };

            // Try to fetch doctor details from API
            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors/{doctorId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    if (result.TryGetProperty("data", out var doctor))
                    {
                        if (doctor.TryGetProperty("fullName", out var name) && name.ValueKind != JsonValueKind.Null)
                            model.DoctorName = name.GetString() ?? "Doctor";
                        if (doctor.TryGetProperty("departmentName", out var dept) && dept.ValueKind != JsonValueKind.Null)
                            model.DoctorDepartment = dept.GetString() ?? "General";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching doctor: {ex.Message}");
                // Continue with defaults if fetching fails
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(CreateAppointmentViewModel model)
        {
            var patientId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (patientId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Validate ModelState
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Additional validation: ensure appointment date is in future
                if (model.AppointmentDate <= DateTime.Now)
                {
                    ModelState.AddModelError(nameof(model.AppointmentDate), "Appointment date must be in the future");
                    return View(model);
                }

                var appointmentDto = new { model.DoctorId, model.AppointmentDate, model.ProblemDescription };
                var json = JsonSerializer.Serialize(appointmentDto);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/appointments/book?patientId={patientId}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Appointment booked successfully!";
                    return RedirectToAction("MyAppointments");
                }
                else
                {
                    // Get the raw error response from API
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorMsg = $"Error: {response.StatusCode} - {errorContent.Substring(0, Math.Min(200, errorContent.Length))}";
                    ModelState.AddModelError("", errorMsg);
                    Console.WriteLine($"API Error: {errorContent}");
                }
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Unable to connect to the server. Please try again.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyAppointments()
        {
            var patientId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (patientId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/appointments/patient/{patientId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response: {responseContent}");
                    
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    
                    if (result.TryGetProperty("data", out var dataProperty))
                    {
                        var appointmentsJson = dataProperty.GetRawText();
                        Console.WriteLine($"Appointments JSON: {appointmentsJson}");
                        
                        try
                        {
                            var appointments = JsonSerializer.Deserialize<List<AppointmentViewModel>>(appointmentsJson, options);
                            Console.WriteLine($"Deserialized {appointments?.Count ?? 0} appointments");
                            return View("MyAppointments", appointments ?? new List<AppointmentViewModel>());
                        }
                        catch (JsonException jsonEx)
                        {
                            Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
                            ViewBag.Error = $"Error parsing appointments: {jsonEx.Message}";
                        }
                    }
                    else
                    {
                        Console.WriteLine("'data' property not found in API response");
                        ViewBag.Error = "Invalid API response format";
                    }
                }
                else
                {
                    Console.WriteLine($"API returned status: {response.StatusCode}");
                    ViewBag.Error = "Failed to load appointments";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                ViewBag.Error = "Unable to connect to the server";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading appointments: {ex.Message}\n{ex.StackTrace}");
                ViewBag.Error = $"Error loading appointments: {ex.Message}";
            }

            return View("MyAppointments", new List<AppointmentViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int appointmentId)
        {
            if (appointmentId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid appointment ID";
                return RedirectToAction("MyAppointments");
            }

            try
            {
                var response = await _httpClient.PatchAsync($"{ApiBaseUrl}/appointments/{appointmentId}/cancel", null);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Appointment cancelled successfully";
                    return RedirectToAction("MyAppointments");
                }
                else
                {
                    // Parse error response
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            TempData["ErrorMessage"] = errorMsg.GetString();
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Failed to cancel appointment";
                        }
                    }
                    catch
                    {
                        TempData["ErrorMessage"] = "An error occurred while cancelling appointment";
                    }
                }
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Unable to connect to the server";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return RedirectToAction("MyAppointments");
        }
    }
}
