using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverymindChallenge.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoProduto { get; set; }
    }
}