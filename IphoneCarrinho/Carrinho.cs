using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IphoneCarrinho
{
    public class Carrinho
    {
        public List<Iphone> Itens { get; set; }

        public Carrinho()
        {
            Itens = new List<Iphone>();
        }

        public void AdicionarIphone(Iphone iphone)
        {
            Itens.Add(iphone);
        }

        public void RemoverIphone(Iphone iphone)
        {
            Itens.Remove(iphone);
        }
    }
}
