using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace JornalAberto2019.Models
{
    //src: https://medium.com/@MoienTajik/using-tinymce-in-asp-net-mvc-ab2cebfce278
    public class Noticias
    {
        public Noticias()
        {
            ListaCategorias = new HashSet<Categorias>();
            NumeroVisualizacoes = 0;
        }

        [Key]
        public int NoticiaID { get; set; }

        public string InseridaPorID { get; set; }
        public virtual ApplicationUser InseridaPor { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNoticia { get; set; }

        [Required]
        [StringLength(80)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(160)]
        public string Descricao { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        public string Corpo { get; set; }

        [Required]
        public bool Aprovada { get; set; }

        public string AprovadaPorID { get; set; }
        public virtual ApplicationUser AprovadaPor { get; set; }

        public int? NumeroVisualizacoes { get; set; }

        // muitos para muitos Categorias
        public virtual ICollection<Categorias> ListaCategorias { get; set; }
    }
}