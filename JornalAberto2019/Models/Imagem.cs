﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Imagem
    {
        [Key]
        public int ImagemID { get; set; }

        [Required]
        [StringLength(60)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(120)]
        public string Path { get; set; }

        public virtual Noticias NoticiaID { get; set; }
    }
}