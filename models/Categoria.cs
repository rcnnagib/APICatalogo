using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore; 

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.models
{
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();            
        }
        [Key]
        public int CategoriaId { get; set; }
        [Required]         
        [MaxLength(80)]
        public string Nome { get; set; }
        
        [MaxLength(300)]
        public string imagemUrl { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}