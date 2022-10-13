using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSI.Models
{
    public class Modelo.Tabelas
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}