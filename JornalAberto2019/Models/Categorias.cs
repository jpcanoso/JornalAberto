using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(60)]
        public string NomeCategoria { get; set; }
    }
}