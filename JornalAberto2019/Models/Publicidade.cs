using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class Publicidade
    {
        [Key]
        public int PublicidadeID { get; set; }

        [ForeignKey("Pagamento")]
        public int PagamentoID { get; set; }
        public virtual Pagamentos Pagamento { get; set; }

        public string Imagem { get; set; }
    }
}