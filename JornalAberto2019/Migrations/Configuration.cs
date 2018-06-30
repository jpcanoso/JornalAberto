using System.Data.Entity.Migrations;
using System.Collections.Generic;
using JornalAberto2019.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JornalAberto2019.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<JornalAberto2019.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JornalAberto2019.Models.ApplicationDbContext context)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var password = "Teste123!";

            // Se a role administrador n�o existir
            if (!roleManager.RoleExists("Administrador"))
            {
                // Adiciona a role
                var role = new ApplicationRole();
                role.Name = "Administrador";
                roleManager.Create(role);

                // Adicionar um primeiro Utilizador para gerir o site com todos os privil�gios
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@jornalaberto.pt";
                user.EmailConfirmed = true;

                var chkUser = userManager.Create(user, password);

                // Se o utilizador for adicionado, vamos conceder-lhe os privil�gios
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Administrador");
                }
            }

            // Criar a regra Moderador
            if (!roleManager.RoleExists("Moderador"))
            {
                var role = new ApplicationRole();
                role.Name = "Moderador";
                roleManager.Create(role);

                // Adicionar um utilizador com as permissoes da role
                var user = new ApplicationUser();
                user.UserName = "moderador";
                user.Email = "moderador@jornalaberto.pt";
                user.EmailConfirmed = true;

                var chkUser = userManager.Create(user, password);

                // Se o utilizador for adicionado, vamos conceder-lhe os privil�gios
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Moderador");
                }
            }

            // Criar a regra Utilizador
            if (!roleManager.RoleExists("Utilizador"))
            {
                var role = new ApplicationRole();
                role.Name = "Utilizador";
                roleManager.Create(role);

                // Adicionar um utilizador com as permissoes da role
                var user = new ApplicationUser
                {
                    UserName = "utilizador",
                    Email = "utilizador@jornalaberto.pt",
                    EmailConfirmed = true
                };

                var chkUser = userManager.Create(user, password);

                // Se o utilizador for adicionado, vamos conceder-lhe os privil�gios
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Utilizador");
                }
            }

            // Seed das categorias
            var categorias = new List<Categorias>
            {
                new Categorias {CategoriaID = 1, NomeCategoria = "Desporto"},
                new Categorias {CategoriaID = 2, NomeCategoria = "Pa�s"},
                new Categorias {CategoriaID = 3, NomeCategoria = "Tecnologia"},
                new Categorias {CategoriaID = 4, NomeCategoria = "Pol�tica"},
                new Categorias {CategoriaID = 5, NomeCategoria = "Fama"},
                new Categorias {CategoriaID = 6, NomeCategoria = "Cultura"}
            };
            categorias.ForEach(cc => context.Categorias.AddOrUpdate(c => c.NomeCategoria, cc));
            context.SaveChanges();
        }
    }
}
