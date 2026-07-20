using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] string id)
        {
            var stock = _context.Stocks.Find(Guid.Parse(id));
            if (stock==null) { return NotFound(); }
            return Ok(stock);
        }

        [HttpPost]
        public IActionResult Write(Stock s)
        {
            _context.Stocks.Add(s);
            _context.SaveChanges();
            return Ok(s);
        }



    }
}
