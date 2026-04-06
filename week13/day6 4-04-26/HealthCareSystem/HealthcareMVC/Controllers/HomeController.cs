using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HealthcareMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserId");

            // If not logged in, show welcome page
            if (string.IsNullOrEmpty(userRole) || !userId.HasValue)
            {
                return View("WelcomeView");
            }

            // Route to role-specific dashboard
            if (userRole == "Doctor")
            {
                return await DoctorDashboard(userId.Value);
            }
            else if (userRole == "Patient")
            {
                return await PatientDashboard(userId.Value);
            }
            else if (userRole == "Admin")
            {
                return await AdminDashboard(userId.Value);
            }

            return View("WelcomeView");
        }

        private async Task<IActionResult> DoctorDashboard(int doctorId)
        {
            try
            {
                // Fetch doctor's appointments
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/appointments/doctor/{doctorId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    
                    // Create dynamic viewbag data
                    ViewBag.UserRole = "Doctor";
                    ViewBag.AppointmentsData = result.GetRawText();
                    
                    return View("DoctorDashboard");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading dashboard: {ex.Message}";
            }

            ViewBag.UserRole = "Doctor";
            ViewBag.AppointmentsData = "[]";
            return View("DoctorDashboard");
        }

        private async Task<IActionResult> PatientDashboard(int patientId)
        {
            try
            {
                // Fetch patient's appointments
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/appointments/patient/{patientId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    
                    ViewBag.UserRole = "Patient";
                    ViewBag.AppointmentsData = result.GetRawText();
                    
                    return View("PatientDashboard");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading dashboard: {ex.Message}";
            }

            ViewBag.UserRole = "Patient";
            ViewBag.AppointmentsData = "[]";
            return View("PatientDashboard");
        }

        private async Task<IActionResult> AdminDashboard(int adminId)
        {
            ViewBag.UserRole = "Admin";
            return View("AdminDashboard");
        }
    }
}
