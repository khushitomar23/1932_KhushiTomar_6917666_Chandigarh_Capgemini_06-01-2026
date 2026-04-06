using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceSite.Web.Models;
using ECommerceSite.Web.Services;
using ECommerceSite.Models.DTOs;

namespace ECommerceSite.Web.Controllers;

public class HomeController : Controller
{
    private readonly IApiService _apiService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IApiService apiService, ILogger<HomeController> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await _apiService.GetAsync<List<ProductDto>>("api/products");
            return View(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching products");
            return View(new List<ProductDto>());
        }
    }

    public async Task<IActionResult> ProductDetails(int id)
    {
        try
        {
            var product = await _apiService.GetAsync<ProductDto>($"api/products/{id}");
            return View(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product");
            return RedirectToAction("Index");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Cart()
    {
        // Cart is managed via JavaScript and sessionStorage
        // This view just displays the items from sessionStorage
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

