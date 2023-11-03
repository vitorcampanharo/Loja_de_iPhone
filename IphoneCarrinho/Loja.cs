using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IphoneCarrinho
{
    public class Loja
    {
        public List<Iphone> iphones = new List<Iphone>();
        public List<Cliente> clientes = new List<Cliente>();

        
        public void CadastrarCliente()
        {
            Console.Clear();
            Nome:
            Console.Write("Digite seu nome (ou 'sair' para voltar ao menu principal): ");
            string nome = Console.ReadLine();          
            if (nome.ToString() == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Erro: É necessário digitar um nome");
                goto Nome;
            }
            else if (nome.Equals("sair", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Saindo ...");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
                return;
            }
            else if (!nome.All(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine("Nome inválido. Deve conter apenas letras.");
                goto Nome;
            }
            else if (clientes.Any(c => c.Nome.ToLower().Trim() == nome.ToLower().Trim()))
            {
                Console.Clear();
                Console.WriteLine("Cliente já cadastrado anteriormente");
                goto Nome;
            }
            Salario:
            Console.Write("Digite seu salario: ");
            double salario;
            if (!double.TryParse(Console.ReadLine(), out salario))
            {
                Console.Clear();
                Console.WriteLine("Erro: Salário deve ser um número válido.");
                goto Salario;
            }
            else if (salario <= 0)
            {
                Console.Clear();
                Console.WriteLine("Erro: Salário não pode ser negativo.");
                goto Salario;
            }
            else
            {
                Cliente cliente = new Cliente(nome, salario);
                clientes.Add(cliente);
                Console.WriteLine("Cliente cadastrado com sucesso!");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }

        }
        public void CadastrarIphone()
        {
            Console.Clear();
            NomeM:
            Console.Write("Digite o nome do modelo (ou 'sair' para voltar ao menu principal): ");
            string nomeM = Console.ReadLine();

            if (nomeM.ToString() == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Erro: É necessário digitar um nome");
                goto NomeM;
            }
            else if (nomeM.Equals("sair", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Saindo ...");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
                return;
            }
            else if (iphones.Any(c => c.NomeM.ToLower().Trim() == nomeM.ToLower().Trim()))
            {
                Console.Clear();
                Console.WriteLine("iPhone já cadastrado anteriormente");
                goto NomeM;
            } 
            Preco:
            Console.Write("Digite o preço: ");
            double preco;
            if (!double.TryParse(Console.ReadLine(), out preco))
            {
                Console.Clear();
                Console.WriteLine("Erro: Preço deve ser um número válido.");
                goto Preco;
            }
            else if (preco <= 0)
            {
                Console.Clear();
                Console.WriteLine("Erro: Preço não pode ser negativo nem começar com zero.");
                goto Preco;
            }
            else
            {
                Iphone iphone = new Iphone(nomeM, preco);
                iphones.Add(iphone);
                Console.WriteLine("Iphone cadastrado com sucesso!");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
        }
        public void AdicionarNoCarrinho()
        {
            Console.Clear();
            if (clientes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
               Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else if (iphones.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var iphone in iphones)
                {
                    Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                }
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);
                }
                nomeIphone:
                Console.Write("Digite o nome do produto que deseja adicionar ao carrinho (Ou 'sair' para voltar ao menu principal): ");
                string nomeIphone = Console.ReadLine();
                var nomeIphoneAdicionado = iphones.FirstOrDefault(I => string.Equals(I.NomeM, nomeIphone, StringComparison.OrdinalIgnoreCase));
                if (nomeIphone.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (nomeIphoneAdicionado == null)
                {
                    Console.WriteLine("Erro: iPhone não encontrado.");
                    goto nomeIphone;
                }
                else
                {
                nomeCliente:
                    Console.Write("Digite seu nome: ");
                    string nomeCliente = Console.ReadLine();
                    var nomeClienteAdicionado = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));

                    if (nomeClienteAdicionado == null)
                    {
                        Console.WriteLine("Erro: Cliente não encontrado.");
                        goto nomeCliente;
                    }
                    else if (!nomeIphoneAdicionado.EstaComprado)
                    {
                        if (nomeClienteAdicionado.Salario < nomeIphoneAdicionado.Preco)
                        {
                            Console.Clear();
                            Console.WriteLine("Erro: Saldo insuficiente para comprar o iPhone.");
                            Console.WriteLine("\r\nTecle 'Enter' para voltar");
                        }
                        else
                        {
                            Console.Clear();
                            nomeClienteAdicionado.CarrinhoDeCompras.AdicionarIphone(nomeIphoneAdicionado);
                            Console.WriteLine("iPhone adicionado ao carrinho com sucesso!");
                            Console.WriteLine("\r\nTecle 'Enter' para voltar");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro: iPhone já foi comprado anteriormente.");
                        Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    }
                }
            }
        }
        public void ComprarDoCarrinho()
        {
            Console.Clear();
            if (clientes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else if (iphones.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);
                }
                nomeCliente:
                Console.WriteLine("Digite seu nome para comprar do carrinho (ou 'sair' para voltar ao menu principal): ");
                string nomeCliente = Console.ReadLine();
                var nomeClienteParaCompra = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));
                if (nomeCliente.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (nomeClienteParaCompra == null)
                {
                    Console.WriteLine("Cliente não encontrado ou não tem carrinho");
                    goto nomeCliente;
                }
                else if (nomeClienteParaCompra.CarrinhoDeCompras.Itens.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Erro: Carrinho inexistente.");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (nomeClienteParaCompra.Salario < nomeClienteParaCompra.CarrinhoDeCompras.Itens.Sum(iphones => iphones.Preco))
                {
                    Console.Clear();
                    Console.WriteLine("Erro: Saldo insuficiente para concluir a compra.");
                    foreach (var iphone in nomeClienteParaCompra.CarrinhoDeCompras.Itens)
                    {
                        Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                    }
                    nomeIphoneParaExcluir:
                    Console.Write("\r\nDigite 'sair' para cancelar. Ou exclua um iPhone: ");
                    string nomeIphoneParaExcluir = Console.ReadLine();
                    if (nomeIphoneParaExcluir.Equals("sair", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Saindo ...");
                        Console.WriteLine("\r\nTecle 'Enter' para voltar");
                        return;
                    }
                    else
                    {
                        var iphoneParaExcluir = nomeClienteParaCompra.CarrinhoDeCompras.Itens.FirstOrDefault(n => n.NomeM.Equals(nomeIphoneParaExcluir, StringComparison.OrdinalIgnoreCase));
                        if (iphoneParaExcluir == null)
                        {
                            Console.WriteLine("iPhone não encontrado no carrinho. Tente novamente.");
                            goto nomeIphoneParaExcluir;
                        }
                        else
                        {
                            Console.Clear();
                            nomeClienteParaCompra.CarrinhoDeCompras.RemoverIphone(iphoneParaExcluir);
                            Console.WriteLine("iPhone removido do carrinho com sucesso!");
                            Console.WriteLine("\r\nTecle 'Enter' para voltar");
                        }
                    }
                }
                else if (nomeClienteParaCompra.Salario >= nomeClienteParaCompra.CarrinhoDeCompras.Itens.Sum(iphones => iphones.Preco))
                {
                    foreach (var iphone in nomeClienteParaCompra.CarrinhoDeCompras.Itens)
                    {
                        Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                    }
                    foreach (var iphone in nomeClienteParaCompra.CarrinhoDeCompras.Itens)
                    {
                        iphone.EstaComprado = true;
                        Console.WriteLine("Parabéns, compra realizada com sucesso");
                    }

                    nomeClienteParaCompra.Salario -= nomeClienteParaCompra.CarrinhoDeCompras.Itens.Sum(iphones => iphones.Preco);
                    nomeClienteParaCompra.CarrinhoDeCompras.Itens.Clear();
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    return;
                }
            }            
        }
        public void EditarSalarioCliente()
        {
            Console.Clear();
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);
                }
                nomeCliente:
                Console.WriteLine("\r\nInforme o nome do cliente (ou 'sair' para voltar ao menu principal): ");
                string nomeCliente = Console.ReadLine();
                var clienteEditarSalario = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));
                if (nomeCliente.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (clienteEditarSalario == null)
                {
                    Console.WriteLine("Cliente não encontrado.");
                    goto nomeCliente;
                }
                else
                {
                Salario:
                    Console.WriteLine("Informe o novo salário:");
                    if (!double.TryParse(Console.ReadLine(), out double novoSalario))
                    {
                        Console.WriteLine("Salário inválido. Digite um valor numérico.");
                        goto Salario;
                    }
                    else if (clienteEditarSalario.Salario == novoSalario)
                    {
                        Console.WriteLine("O novo salário não pode ser igual ao anterior, não faz sentido");
                        goto Salario;
                    }
                    else
                    {
                        Console.Clear();
                        clienteEditarSalario.Salario = novoSalario;
                        Console.WriteLine("Salário de " + nomeCliente + " atualizado com sucesso! \r\n Novo salário: " + novoSalario);
                        Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    }
                }
            }
            
        }
        public void EditarPrecoIPhone()
        {
            Console.Clear();
            if (iphones.Count == 0)
            {
                Console.WriteLine("Nenhum iPhone cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var iphone in iphones)
                {
                    Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                }
                modeloIPhone:
                Console.WriteLine("\r\nInforme o modelo do iPhone (ou 'sair' para voltar ao menu principal): ");
                string modeloIPhone = Console.ReadLine();
                var iphoneEditarPreco = iphones.FirstOrDefault(I => string.Equals(I.NomeM, modeloIPhone, StringComparison.OrdinalIgnoreCase));
                if (modeloIPhone.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (iphoneEditarPreco == null)
                {
                    Console.WriteLine("iPhone não encontrado.");
                    goto modeloIPhone;
                }
                else
                {
                Preco:
                    Console.WriteLine("Informe o novo preço:");
                    if (!double.TryParse(Console.ReadLine(), out double novoPreco))
                    {
                        Console.WriteLine("preço inválido. Digite um valor numérico.");
                        goto Preco;
                    }
                    else if (iphoneEditarPreco.Preco == novoPreco)
                    {
                        Console.WriteLine("O novo preço não pode ser igual ao anterior, não fz sentido");
                        goto Preco;
                    }
                    else
                    {
                        Console.Clear();
                        iphoneEditarPreco.Preco = novoPreco;
                        Console.WriteLine("Preço do " + modeloIPhone + " atualizado com sucesso! \r\n Novo preço: " + novoPreco);
                        Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    }
                }
            }
            
        }
        public void ExcluirCliente()
        {
            Console.Clear();
            if(clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);
                }
                nomeCliente:
                Console.WriteLine("Informe o nome do cliente a ser excluído (ou 'sair' para voltar ao menu iniciar): ");
                string nomeCliente = Console.ReadLine();
                var clienteExcluir = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));
                if (nomeCliente.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (clienteExcluir == null)
                {
                    Console.WriteLine("Cliente não encontrado.");
                    goto nomeCliente;
                }
                else
                {
                    Console.Clear();
                    clientes.Remove(clienteExcluir);
                    Console.WriteLine("Cliente excluído com sucesso!");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
            }
            
        }
        public void ExcluirIphoneDoCadastro()
        {
            Console.Clear();
            if(iphones.Count == 0)
            {
                Console.WriteLine("Nenhum iPhone cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var iphone in iphones)
                {
                    Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                }
                nomeIphone:
                Console.WriteLine("\r\nInforme o nome do iphone a ser excluído (ou 'sair' para voltar ao menu principal): ");
                string nomeIphone = Console.ReadLine();
                var nomeIphoneExcluido = iphones.FirstOrDefault(c => string.Equals(c.NomeM, nomeIphone, StringComparison.OrdinalIgnoreCase));
                if (nomeIphone.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else if (nomeIphoneExcluido == null)
                {
                    Console.WriteLine("iPhone não encontrado.");
                    goto nomeIphone;
                }
                else
                {
                    Console.Clear();
                    iphones.Remove(nomeIphoneExcluido);
                    Console.WriteLine("Iphone excluído com sucesso!");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
            }
            
        }
        public void ExcluirIPhoneDoCarrinho()
        {
            Console.Clear ();
            if (clientes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else if (iphones.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                nomeCliente:
                Console.WriteLine("Informe o nome do cliente (ou 'sair' para voltar ao menu iniciar): ");
                string nomeCliente = Console.ReadLine();
                var clienteCarrinho = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));
                if (nomeCliente.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    return;
                }
                else if (clienteCarrinho == null)
                {
                    Console.WriteLine("Cliente não encontrado.");
                    goto nomeCliente;
                }
                else if (clienteCarrinho.CarrinhoDeCompras.Itens.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Carrinho deste cliente está vazio");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else
                {
                    Console.Clear();
                    foreach (var iphone in clienteCarrinho.CarrinhoDeCompras.Itens)
                    {
                        Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                    }
                    modeloIPhone:
                    Console.WriteLine("\r\nInforme o modelo do iPhone a ser excluído do carrinho:");
                    string modeloIPhone = Console.ReadLine();
                    var iphoneCarrinho = clienteCarrinho.CarrinhoDeCompras.Itens.FirstOrDefault(i => string.Equals(i.NomeM, modeloIPhone, StringComparison.OrdinalIgnoreCase));
                    if (iphoneCarrinho == null)
                    {
                        Console.WriteLine("IPhone não encontrado no carrinho desse cliente.");
                        goto modeloIPhone;
                    }
                    else
                    {
                        Console.Clear();
                        clienteCarrinho.CarrinhoDeCompras.Itens.Remove(iphoneCarrinho);
                        Console.WriteLine("IPhone excluído do carrinho de " + nomeCliente + " com sucesso!");
                        Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    }
                }
            }
        }
        public void ConsultarIphonesDoCarrinho()
        {
            Console.Clear();
            if (clientes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else if (iphones.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar no mínimo um cliente e um iphone para adicionar itens no carrinho");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);
                }
                nomeCliente:
                Console.WriteLine("Informe o nome do cliente (ou'sair' para voltar ao menu principal): ");
                string nomeCliente = Console.ReadLine();
                var clienteCarrinho = clientes.FirstOrDefault(c => string.Equals(c.Nome, nomeCliente, StringComparison.OrdinalIgnoreCase));
                if (nomeCliente.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Saindo ...");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                    return;
                }
                else if (clienteCarrinho == null)
                {
                    Console.Clear();
                    Console.WriteLine("Cliente não encontrado.");
                    goto nomeCliente;
                }
                else if (clienteCarrinho.CarrinhoDeCompras.Itens.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Carrinho deste cliente está vazio");
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
                else
                {
                    Console.Clear();
                    foreach (var iphone in clienteCarrinho.CarrinhoDeCompras.Itens)
                    {
                        Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                    }
                    Console.WriteLine("\r\nTecle 'Enter' para voltar");
                }
            }                     
        }
        public void ConsultarClientes()
        {
            Console.Clear();
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome + "; Salario: " + cliente.Salario);                    
                }
                Console.WriteLine("\r\nTecle 'Enter' para sair");
            }
        }
        public void ConsultarIphones()
        {
            Console.Clear();
            if (iphones.Count == 0)
            {
                Console.WriteLine("Nenhum iPhone cadastrado ainda");
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }
            else
            {
                foreach (var iphone in iphones)
                {
                    Console.WriteLine(iphone.NomeM + " " + "R$ " + iphone.Preco);
                }
                Console.WriteLine("\r\nTecle 'Enter' para voltar");
            }        
        }
    }
}
