using Microsoft.AspNetCore.Mvc;
using HealthcareMVC.Models;
using System.Net.Http;
using System.Text.Json;

namespace HealthcareMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7200/api";

        public AuthController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Validate ModelState
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    var user = result.GetProperty("data");
                    var userId = user.GetProperty("userId").GetInt32();
                    var userName = user.GetProperty("fullName").GetString();
                    var userRole = user.GetProperty("role").GetString();

                    HttpContext.Session.SetInt32("UserId", userId);
                    HttpContext.Session.SetString("UserName", userName);
                    HttpContext.Session.SetString("UserRole", userRole);

                    // Redirect based on role
                    if (userRole == "Admin")
                        return RedirectToAction("Dashboard", "Admin");
                    else if (userRole == "Doctor")
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Parse error response from API
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            ModelState.AddModelError("", errorMsg.GetString());
                        }
                        else
                        {
                            ModelState.AddModelError("", "Login failed. Please check your credentials.");
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("", "An error occurred during login");
                    }
                }
            }
            catch (HttpRequestException ex)
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Validate ModelState (includes custom password comparison validation)
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var registerDto = new { model.FullName, model.Email, model.Password, model.Role };
                var json = JsonSerializer.Serialize(registerDto);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBaseUrl}/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in with your credentials.";
                    return RedirectToAction("Login");
                }
                else
                {
                    // Parse error response from API
                    var errorContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var errorResult = JsonSerializer.Deserialize<JsonElement>(errorContent);
                        if (errorResult.TryGetProperty("message", out var errorMsg))
                        {
                            ModelState.AddModelError("", errorMsg.GetString());
                        }
                        else if (errorResult.TryGetProperty("errors", out var errors))
                        {
                            foreach (var err in errors.EnumerateArray())
                            {
                                ModelState.AddModelError("", err.GetString());
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Registration failed. Please try again.");
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("", "An error occurred during registration");
                    }
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
