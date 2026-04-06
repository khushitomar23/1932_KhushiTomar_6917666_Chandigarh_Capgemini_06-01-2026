using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TransactionAPI.Data;
using TransactionAPI.DTOs;

namespace TransactionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TransactionsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var transactions = _context.Transactions
                .Where(t => t.UserId == userId)
                .ToList();

            var result = _mapper.Map<List<TransactionDto>>(transactions);
            return Ok(result);
        }
    }
}