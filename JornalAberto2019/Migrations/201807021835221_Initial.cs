namespace JornalAberto2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        NoticiaID = c.Int(nullable: false, identity: true),
                        InseridaPorID = c.String(nullable: false, maxLength: 128),
                        DataNoticia = c.DateTime(nullable: false, storeType: "date"),
                        Titulo = c.String(nullable: false, maxLength: 80),
                        Descricao = c.String(nullable: false, maxLength: 160),
                        Corpo = c.String(nullable: false),
                        Aprovada = c.Boolean(nullable: false),
                        AprovadaPorID = c.String(nullable: false, maxLength: 128),
                        NumeroVisualizacoes = c.Int(),
                    })
                .PrimaryKey(t => t.NoticiaID)
                .ForeignKey("dbo.AspNetUsers", t => t.AprovadaPorID)
                .ForeignKey("dbo.AspNetUsers", t => t.InseridaPorID)
                .Index(t => t.InseridaPorID)
                .Index(t => t.AprovadaPorID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(maxLength: 60),
                        Pontos = c.Int(),
                        Foto = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagemID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 60),
                        Path = c.String(nullable: false, maxLength: 120),
                        NoticiaID_NoticiaID = c.Int(),
                    })
                .PrimaryKey(t => t.ImagemID)
                .ForeignKey("dbo.Noticias", t => t.NoticiaID_NoticiaID)
                .Index(t => t.NoticiaID_NoticiaID);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        PagamentoID = c.Int(nullable: false, identity: true),
                        PagoPor = c.String(maxLength: 128),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pago = c.Boolean(nullable: false),
                        DataPagamento = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.PagamentoID)
                .ForeignKey("dbo.AspNetUsers", t => t.PagoPor)
                .Index(t => t.PagoPor);
            
            CreateTable(
                "dbo.Publicidades",
                c => new
                    {
                        PublicidadeID = c.Int(nullable: false, identity: true),
                        PagamentoID = c.Int(nullable: false),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.PublicidadeID)
                .ForeignKey("dbo.Pagamentos", t => t.PagamentoID)
                .Index(t => t.PagamentoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Name = c.String(),
                        Pontos = c.Int(),
                        Foto = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoticiasCategorias",
                c => new
                    {
                        Noticias_NoticiaID = c.Int(nullable: false),
                        Categorias_CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Noticias_NoticiaID, t.Categorias_CategoriaID })
                .ForeignKey("dbo.Noticias", t => t.Noticias_NoticiaID)
                .ForeignKey("dbo.Categorias", t => t.Categorias_CategoriaID)
                .Index(t => t.Noticias_NoticiaID)
                .Index(t => t.Categorias_CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Publicidades", "PagamentoID", "dbo.Pagamentos");
            DropForeignKey("dbo.Pagamentos", "PagoPor", "dbo.AspNetUsers");
            DropForeignKey("dbo.Imagens", "NoticiaID_NoticiaID", "dbo.Noticias");
            DropForeignKey("dbo.NoticiasCategorias", "Categorias_CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.NoticiasCategorias", "Noticias_NoticiaID", "dbo.Noticias");
            DropForeignKey("dbo.Noticias", "InseridaPorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Noticias", "AprovadaPorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.NoticiasCategorias", new[] { "Categorias_CategoriaID" });
            DropIndex("dbo.NoticiasCategorias", new[] { "Noticias_NoticiaID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Publicidades", new[] { "PagamentoID" });
            DropIndex("dbo.Pagamentos", new[] { "PagoPor" });
            DropIndex("dbo.Imagens", new[] { "NoticiaID_NoticiaID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Noticias", new[] { "AprovadaPorID" });
            DropIndex("dbo.Noticias", new[] { "InseridaPorID" });
            DropTable("dbo.NoticiasCategorias");
            DropTable("dbo.UserViewModels");
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Publicidades");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Imagens");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Noticias");
            DropTable("dbo.Categorias");
        }
    }
}
