using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Utilizadores
    {
        [Key]
        public int UtilizadorID { get; set; }

        public virtual ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string AspNetID { get; set; }

        [StringLength(60)]
        public string Nome { get; set; }

        public int? Pontos { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Noticias> Inseriu { get; set; }
        public virtual ICollection<Noticias> Aprovou { get; set; }
    }
}