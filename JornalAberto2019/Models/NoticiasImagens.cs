using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class NoticiasImagens
    {
        public virtual Noticias Noticia { get; set; }
        [Key, Column(Order = 3)]
        [ForeignKey("Noticia")]
        public int NoticiaID { get; set; }

        public virtual Imagens Imagem { get; set; }
        [Key, Column(Order = 4)]
        [ForeignKey("Imagem")]
        public int ImagemID { get; set; }
    }
}