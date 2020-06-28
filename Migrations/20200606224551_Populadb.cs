using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into \"Categorias\"(\"Nome\", \"imagemUrl\") " +
                "Values('Bebidas', 'http://www.maccoratti.net/Imagens/1.jpg')");

            mb.Sql("insert into \"Categorias\"(\"Nome\", \"imagemUrl\") " +
                "Values('Lanches', 'http://www.maccoratti.net/Imagens/2.jpg')");

            mb.Sql("insert into \"Categorias\"(\"Nome\", \"imagemUrl\") " +
                "Values('Sobremesas', 'http://www.maccoratti.net/Imagens/3.jpg')");            

            mb.Sql("insert into \"Produtos\"(\"Nome\", \"Descricao\", \"Preco\", \"ImagemUrl\", \"Estoque\", \"DataCadastro\", \"CategoriaId\")"+
                "Values('Coca-Cola Diet', 'Refrigerante de cola 350 ml', 5.45, 'http://www.maccoratti.net/Imagens/coca.jpg', 50, now(),"+
                "(select \"CategoriaId\" from \"Categorias\" where \"Nome\" = 'Bebidas'))");
            
            mb.Sql("insert into \"Produtos\"(\"Nome\", \"Descricao\", \"Preco\", \"ImagemUrl\", \"Estoque\", \"DataCadastro\", \"CategoriaId\") "+
                "Values('Lanche de Atum', 'lanche de Atum com maionese', 8.50, 'http://www.maccoratti.net/Imagens/atum.jpg', 10, now(),"+
                "(select \"CategoriaId\" from \"Categorias\" where \"Nome\" = 'Lanches'))");
            
            mb.Sql("insert into \"Produtos\"(\"Nome\", \"Descricao\", \"Preco\", \"ImagemUrl\", \"Estoque\", \"DataCadastro\", \"CategoriaId\") "+
                "Values('Pudim 100 g', 'Pudim de leite condensado 100g', 6.75, 'http://www.maccoratti.net/Imagens/pudim.jpg', 20, now(),"+
                "(select \"CategoriaId\" from \"Categorias\" where \"Nome\" = 'Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {            
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
