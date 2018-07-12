using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class CategoriasNoticias
    {
        public int CategoriaID { get; set; }
        public string NomeCategoria { get; set; }
        public bool Atribuido { get; set; }
    }
}