using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;

namespace EcommerceApp.ViewComponents
{
  public class CategoryMenuViewComponent : ViewComponent
  {
    private readonly AppDbContext _context;

    public CategoryMenuViewComponent(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var categories = await _context.Categories
          .OrderBy(c => c.Name)
          .ToListAsync();

      return View(categories);
    }
  }
}