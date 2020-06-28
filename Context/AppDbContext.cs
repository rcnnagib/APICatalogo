
using Microsoft.EntityFrameworkCore; 
using APICatalogo.models;
using System.Collections.Generic;
namespace APICatalogo.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}