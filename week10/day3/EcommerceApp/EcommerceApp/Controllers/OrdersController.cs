using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Controllers
{
  public class OrdersController : Controller
  {
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: Orders
    public async Task<IActionResult> Index()
    {
      var orders = await _context.Orders
          .Include(o => o.Customer)
          .ToListAsync();
      return View(orders);
    }

    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Orders
          .Include(o => o.Customer)
          .Include(o => o.OrderDetails)
              .ThenInclude(d => d.Product)
          .FirstOrDefaultAsync(m => m.OrderId == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }
  }
}