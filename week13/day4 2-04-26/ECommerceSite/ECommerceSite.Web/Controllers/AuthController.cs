using Microsoft.AspNetCore.Mvc;
using ECommerceSite.Web.Services;

namespace ECommerceSite.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiService _apiService;

        public AuthController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Username and password are required";
                return View();
            }

            var loginData = new { username, password };
            var response = await _apiService.PostAsync<Dictionary<string, object>>("api/Auth/login", loginData);

            if (response != null)
            {
                // Store token in session or local storage
                HttpContext.Session.SetString("AccessToken", response["accessToken"]?.ToString() ?? "");
                HttpContext.Session.SetString("User", username);
                _apiService.SetAuthToken(response["accessToken"]?.ToString() ?? "");
                
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string fullName)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName))
            {
                ViewBag.Error = "All fields are required";
                return View();
            }

            var registerData = new { username, email, password, fullName };
            var response = await _apiService.PostAsync<Dictionary<string, object>>("api/Auth/register", registerData);

            if (response != null)
            {
                // Redirect to login page after successful registration
                TempData["RegistrationSuccess"] = "✅ Registration successful! Please log in with your credentials.";
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Registration failed. Please try again.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AccessToken");
            HttpContext.Session.Remove("User");
            _apiService.ClearAuthToken();
            return RedirectToAction("Index", "Home");
        }
    }
}
