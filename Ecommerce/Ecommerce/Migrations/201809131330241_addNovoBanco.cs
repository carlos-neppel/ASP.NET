namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNovoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        CarrinhoId = c.String(),
                        Produto_ProdutoId = c.Int(),
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.Produto_ProdutoId)
                .Index(t => t.Venda_VendaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Imagem = c.String(),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Cep = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        CarrinhoId = c.String(),
                    })
                .PrimaryKey(t => t.VendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.ItemVendas", "Produto_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.ItemVendas", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItemVendas", new[] { "Produto_ProdutoId" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtos");
            DropTable("dbo.ItemVendas");
            DropTable("dbo.Categorias");
        }
    }
}
