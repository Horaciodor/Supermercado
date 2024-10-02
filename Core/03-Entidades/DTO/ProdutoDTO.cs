using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades.DTO
{
    internal class ProdutoDTO
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome} - Preco: {Preco}";
        }
    }
}
