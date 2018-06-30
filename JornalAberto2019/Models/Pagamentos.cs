using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Pagamentos
    {
        [Key]
        public int PagamentoID { get; set; }

        [ForeignKey("Utilizador")]
        public string PagoPor { get; set; }
        public virtual ApplicationUser Utilizador { get; set; }

        //[ForeignKey("Publicidade")]
        //public int PublicidadeID { get; set; }
        //public virtual Publicidade Publicidade { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public bool Pago { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataPagamento { get; set; }
    }
}