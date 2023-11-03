using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IphoneCarrinho
{
    public class Iphone
    {
        public string NomeM { get; set; }
        public double Preco { get; set; }
        public bool EstaComprado { get; set; }

        public Iphone(string nomeM, double preco)
        {
            NomeM = nomeM;
            Preco = preco;
            EstaComprado = false;
        }
    }
}
