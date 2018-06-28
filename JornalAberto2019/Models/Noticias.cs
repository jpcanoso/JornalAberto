using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Noticias
    {
        public Noticias()
        {
            Categorias = new HashSet<NoticiasCategorias>();
            Imagens = new HashSet<NoticiasImagens>();
        }

        [Key]
        public int NoticiaID { get; set; }


        public int InseridaPorID { get; set; }
        public virtual Utilizadores InseridaPor { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataNoticia { get; set; }

        public virtual ICollection<NoticiasCategorias> Categorias { get; set; }

        public virtual ICollection<NoticiasImagens> Imagens { get; set; }

        [Required]
        [StringLength(80)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(160)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(1000)]
        public string Corpo { get; set; }

        [Required]
        public bool Aprovada { get; set; }

        public int AprovadaPorID { get; set; }
        public virtual Utilizadores AprovadaPor { get; set; }

        public int? NumeroVisualizacoes { get; set; }
    }
}