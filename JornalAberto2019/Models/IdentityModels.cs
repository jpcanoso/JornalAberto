using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JornalAberto2019.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(60, ErrorMessage = "O Nome não pode possuir mais que 60 caracteres.")]
        public string Nome { get; set; }

        public int? Pontos { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Noticias> Inseriu { get; set; }
        public virtual ICollection<Noticias> Aprovou { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Nomes das tabelas
        public virtual DbSet<Categorias> Categorias { get; set; }                   // Categorias
        public virtual DbSet<Imagens> Imagens { get; set; }                         // Imagens
        public virtual DbSet<NoticiasCategorias> NoticiasCategorias { get; set; }   // NoticiasCategorias
        public virtual DbSet<NoticiasImagens> NoticiasImagens { get; set; }         // NoticiasImagens
        public virtual DbSet<Noticias> Noticias { get; set; }                       // Noticias
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }               // Utilizadores
        public virtual DbSet<Pagamentos> Pagamentos { get; set; }                   // Pagamentos
        public virtual DbSet<Publicidade> Publicidade { get; set; }                 // Publicidade

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

            // Multiplas chaves forasteiras na mesma tabela
            modelBuilder.Entity<Noticias>()
                .HasRequired(n => n.InseridaPor)
                .WithMany(u => u.Inseriu)
                .HasForeignKey(n => n.InseridaPorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Noticias>()
                .HasRequired(n => n.AprovadaPor)
                .WithMany(u => u.Aprovou)
                .HasForeignKey(n => n.AprovadaPorID)
                .WillCascadeOnDelete(false);
        }

        //public System.Data.Entity.DbSet<JornalAberto2019.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}