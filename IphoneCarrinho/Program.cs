using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IphoneCarrinho
{
    public class Program
    {
        static void Main(string[] args)
        {
            Loja loja = new Loja();
            int selectedOption = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Loja - Menu:");
                Console.Write("Escolha uma opção: \r\n");
                for (int i = 1; i <= 13; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.Write("=> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    switch (i)
                    {
                        case 1:
                            Console.WriteLine("1. Cadastrar cliente");
                            break;
                        case 2:
                            Console.WriteLine("2. Cadastrar iPhone");
                            break;
                        case 3:
                            Console.WriteLine("3. Adicionar ao carrinho");
                            break;
                        case 4:
                            Console.WriteLine("4. Finalizar compra");
                            break;
                        case 5:
                            Console.WriteLine("5. Editar salário do cliente");
                            break;
                        case 6:
                            Console.WriteLine("6. Editar preço do iPhone");
                            break;
                        case 7:
                            Console.WriteLine("7. Excluir cliente cadastrado");
                            break;
                        case 8:
                            Console.WriteLine("8. Excluir iPhone Cadastrado na loja");
                            break;
                        case 9:
                            Console.WriteLine("9. Excluir iPhone do carrinho do cliente");
                            break;
                        case 10:
                            Console.WriteLine("10. Consultar clientes cadastrados");
                            break;
                        case 11:
                            Console.WriteLine("11. Consultar iphones cadastrados");
                            break;
                        case 12:
                            Console.WriteLine("12. Consultar iphones no carrinho do cliente");
                            break;
                        case 13:
                            Console.WriteLine("13. Sair");
                            break;
                        default:
                            break;
                    }
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = Math.Max(1, selectedOption - 1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = Math.Min(13, selectedOption + 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    HandleMenuOption(selectedOption, loja);
                }
                void HandleMenuOption(int option, Loja lojaParam)
                {
                    switch (option)
                    {
                        case 1:
                            lojaParam.CadastrarCliente();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            lojaParam.CadastrarIphone();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            lojaParam.AdicionarNoCarrinho();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            lojaParam.ComprarDoCarrinho();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 5:
                            lojaParam.EditarSalarioCliente();
                            Console.ReadLine();
                            Console.Clear();                         
                            break;
                        case 6:
                            lojaParam.EditarPrecoIPhone();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 7:
                            loja.ExcluirCliente();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 8:
                            loja.ExcluirIphoneDoCadastro();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 9:
                            loja.ExcluirIPhoneDoCarrinho();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 10:
                            loja.ConsultarClientes();
                            Console.ReadLine();
                            Console.Clear(); 
                            break;
                        case 11:
                            loja.ConsultarIphones();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 12:
                            loja.ConsultarIphonesDoCarrinho();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 13:
                            Console.WriteLine("Saindo do programa.");
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
