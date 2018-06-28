using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class NoticiasCategorias
    {
        public virtual Noticias Noticia { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Noticia")]
        public int NoticiaID { get; set; }

        public virtual Categorias Categoria { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
    }
}