using System;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Produto produto)
        {
            //teste
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine(await _context.Produtos.ToListAsync());
            return Ok(await _context.Produtos.Where(p => p.Id == 1).ToListAsync());
        }
    }
}