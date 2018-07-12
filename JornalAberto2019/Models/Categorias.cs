using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Categorias
    {
        public Categorias()
        {
            ListaNoticias = new HashSet<Noticias>();
        }

        [Key]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(60)]
        public string NomeCategoria { get; set; }

        public bool Menu { get; set; }

        public virtual ICollection<Noticias> ListaNoticias { get; set; }
    }
}