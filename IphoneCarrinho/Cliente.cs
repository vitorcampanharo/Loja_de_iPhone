using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IphoneCarrinho
{
    public class Cliente
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public Carrinho CarrinhoDeCompras { get; set; }
        public Cliente(string nome, double salario)
        {
            Nome = nome;
            Salario = salario;
            CarrinhoDeCompras = new Carrinho();
        }

 

    }
}
