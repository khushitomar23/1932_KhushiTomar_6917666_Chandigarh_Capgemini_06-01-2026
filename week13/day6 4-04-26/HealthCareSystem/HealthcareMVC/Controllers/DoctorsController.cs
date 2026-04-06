using Microsoft.AspNetCore.Mvc;
using HealthcareMVC.Models;
using System.Net.Http;
using System.Text.Json;

namespace HealthcareMVC.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public DoctorsController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
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
                    return View(doctors);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading doctors: {ex.Message}";
            }

            return View(new List<DoctorViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int doctorId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/doctors/{doctorId}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent, options);
                    var doctorJson = result.GetProperty("data").GetRawText();
                    var doctor = JsonSerializer.Deserialize<DoctorViewModel>(doctorJson, options);
                    return View(doctor);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading doctor details: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
