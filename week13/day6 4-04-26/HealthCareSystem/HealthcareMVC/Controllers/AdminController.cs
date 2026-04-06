using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using HealthcareMVC.Models;

namespace HealthcareMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public AdminController()
        {
            _httpClient = new HttpClient();
        }

        private bool CheckAdminRole()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            return userRole == "Admin";
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                // Get doctors count
                var doctorsResponse = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors");
                var doctorsCount = 0;
                if (doctorsResponse.IsSuccessStatusCode)
                {
                    var doctorsJson = await doctorsResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(doctorsJson, options);
                    var data = result.GetProperty("data");
                    doctorsCount = data.GetArrayLength();
                }

                // Get patients count
                var patientsResponse = await _httpClient.GetAsync($"{ApiBaseUrl}/users/patients");
                var patientsCount = 0;
                if (patientsResponse.IsSuccessStatusCode)
                {
                    var patientsJson = await patientsResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(patientsJson, options);
                    var data = result.GetProperty("data");
                    patientsCount = data.GetArrayLength();
                }

                ViewBag.DoctorsCount = doctorsCount;
                ViewBag.PatientsCount = patientsCount;
                ViewBag.AppointmentsCount = 0; // Can be calculated from appointments endpoint

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading dashboard: {ex.Message}";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageDoctors()
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    var doctorsJson = result.GetProperty("data").GetRawText();
                    var doctors = JsonSerializer.Deserialize<List<DoctorViewModel>>(doctorsJson, options);
                    return View("ManageDoctors", doctors ?? new List<DoctorViewModel>());
                }
                else
                {
                    ViewBag.Error = "Failed to load doctors";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading doctors: {ex.Message}";
            }

            return View("ManageDoctors", new List<DoctorViewModel>());
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorViewModel model)
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model.FullName,
                        model.Email,
                        Password = "Doctor@123", // Default password
                        model.DepartmentId,
                        model.Specialization,
                        model.ExperienceYears,
                        model.Availability
                    }),
                    System.Text.Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/doctors", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Doctor added successfully!";
                    return RedirectToAction("ManageDoctors");
                }
                else
                {
                    // Parse error response from API
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent, options);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            ViewBag.Error = errorMsg.GetString();
                        }
                        else if (errorResult.TryGetProperty("errors", out var errors))
                        {
                            var errorList = errors.EnumerateArray().Select(e => e.GetString()).ToList();
                            ViewBag.Error = string.Join("; ", errorList);
                        }
                        else if (errorResult.TryGetProperty("error", out var error))
                        {
                            ViewBag.Error = error.GetString();
                        }
                        else
                        {
                            ViewBag.Error = $"Failed to add doctor: {errorContent}";
                        }
                    }
                    catch (Exception parseEx)
                    {
                        ViewBag.Error = errorContent ?? "Failed to add doctor";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error adding doctor: {ex.Message}";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditDoctor(int id)
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    var doctorJson = result.GetProperty("data").GetRawText();
                    var doctor = JsonSerializer.Deserialize<DoctorViewModel>(doctorJson, options);
                    return View(doctor);
                }
                else
                {
                    ViewBag.Error = "Doctor not found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading doctor: {ex.Message}";
            }

            return RedirectToAction("ManageDoctors");
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(int id, DoctorViewModel model)
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model.FullName,
                        model.Email,
                        model.DepartmentId,
                        model.Specialization,
                        model.ExperienceYears,
                        model.Availability
                    }),
                    System.Text.Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PutAsync($"{ApiBaseUrl}/doctors/{id}", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Doctor updated successfully!";
                    return RedirectToAction("ManageDoctors");
                }
                else
                {
                    ViewBag.Error = "Failed to update doctor";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error updating doctor: {ex.Message}";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/doctors/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Doctor deleted successfully!";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent, options);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            TempData["Error"] = errorMsg.GetString();
                        }
                        else if (errorResult.TryGetProperty("error", out var error))
                        {
                            TempData["Error"] = error.GetString();
                        }
                        else
                        {
                            TempData["Error"] = $"Delete failed: {errorContent}";
                        }
                    }
                    catch
                    {
                        TempData["Error"] = $"Delete failed: {errorContent}";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting doctor: {ex.Message}";
            }

            return RedirectToAction("ManageDoctors");
        }

        [HttpGet]
        public async Task<IActionResult> ManagePatients()
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/users/patients");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    var patientsJson = result.GetProperty("data").GetRawText();
                    var patients = JsonSerializer.Deserialize<List<UserViewModel>>(patientsJson, options);
                    return View("ManagePatients", patients ?? new List<UserViewModel>());
                }
                else
                {
                    ViewBag.Error = "Failed to load patients";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading patients: {ex.Message}";
            }

            return View("ManagePatients", new List<UserViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> DeletePatient(int userId)
        {
            if (!CheckAdminRole())
                return RedirectToAction("Index", "Home");

            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/users/patients/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Patient deleted successfully!";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent, options);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            TempData["Error"] = errorMsg.GetString();
                        }
                        else if (errorResult.TryGetProperty("error", out var error))
                        {
                            TempData["Error"] = error.GetString();
                        }
                        else
                        {
                            TempData["Error"] = $"Delete failed: {errorContent}";
                        }
                    }
                    catch
                    {
                        TempData["Error"] = $"Delete failed: {errorContent}";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting patient: {ex.Message}";
            }

            return RedirectToAction("ManagePatients");
        }
    }
}
