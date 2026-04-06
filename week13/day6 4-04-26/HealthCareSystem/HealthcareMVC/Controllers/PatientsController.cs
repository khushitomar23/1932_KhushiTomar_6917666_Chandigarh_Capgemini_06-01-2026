using Microsoft.AspNetCore.Mvc;
using HealthcareMVC.Models;
using System.Text.Json;

namespace HealthcareMVC.Controllers
{
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public PatientsController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
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
                    
                    return View(patients ?? new List<UserViewModel>());
                }
                else
                {
                    ViewBag.Error = "Failed to load patients";
                }
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "Unable to connect to the server";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading patients: {ex.Message}";
            }

            return View(new List<UserViewModel>());
        }

        [HttpGet]
        public IActionResult Prescriptions()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Auth");

            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Patient")
                return RedirectToAction("Index", "Home");

            // Sample prescriptions data
            var prescriptions = new List<dynamic>
            {
                new { PrescriptionId = 1, DoctorName = "Dr. Rajesh Kumar", MedicineName = "Aspirin", Dosage = "500mg", Frequency = "2 times daily", StartDate = "2026-04-01", EndDate = "2026-04-15", Status = "Active" },
                new { PrescriptionId = 2, DoctorName = "Dr. Priya Singh", MedicineName = "Metformin", Dosage = "1000mg", Frequency = "Once daily", StartDate = "2026-03-15", EndDate = "2026-05-15", Status = "Active" },
                new { PrescriptionId = 3, DoctorName = "Dr. Amit Patel", MedicineName = "Ibuprofen", Dosage = "400mg", Frequency = "3 times daily", StartDate = "2026-03-01", EndDate = "2026-03-31", Status = "Expired" }
            };

            return View(prescriptions);
        }

        [HttpGet]
        public IActionResult Billing()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Auth");

            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Patient")
                return RedirectToAction("Index", "Home");

            // Sample billing data
            var bills = new List<dynamic>
            {
                new { BillId = 1, Date = "2026-03-15", ConsultationFee = 500, MedicineCharges = 1200, TotalAmount = 1700, Status = "Paid", PaymentDate = "2026-03-16" },
                new { BillId = 2, Date = "2026-03-22", ConsultationFee = 500, MedicineCharges = 800, TotalAmount = 1300, Status = "Pending", PaymentDate = (string)null },
                new { BillId = 3, Date = "2026-04-01", ConsultationFee = 500, MedicineCharges = 1500, TotalAmount = 2000, Status = "Pending", PaymentDate = (string)null }
            };

            return View(bills);
        }
    }
}
