using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Imagens
    {

        [Key]
        public int ImagemID { get; set; }

        [Required]
        [StringLength(60)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(120)]
        public string Path { get; set; }

        public Noticias NoticiaID { get; set; }
    }
}