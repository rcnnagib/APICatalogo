using Microsoft.AspNetCore.Mvc;
using APICatalogo.models;
using System.Collections.Generic;
using APICatalogo.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

         [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                NotFound();
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto )
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId}, produto);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put( int id, [FromBody] Produto produto )
        {
            if(id != produto.ProdutoId ){
                return BadRequest();
            }            
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
         {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }
        
    }
}