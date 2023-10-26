using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas
{
    internal class Gerenciador
    {
        private Clientes GerenciarClientes = new Clientes();
        private Produtos GerenciarProdutos = new Produtos();
        private Venda GerenciarVendas = new Venda();

        public List<Produtos> listaProdutos = new List<Produtos>();
        public List<Clientes> listaClientes = new List<Clientes>();
        public List<Venda> listaVenda = new List<Venda>();




        public Gerenciador() { }

        public void MenuPrincipal()
        {
            

            int menu = 0;

            while (menu != 4)
            {
                Console.WriteLine("----- MENU PRINCIPAL ------");
                Console.WriteLine("1 - Gerenciar Cliente.");
                Console.WriteLine("2 - Gerenciar Produtos.");
                Console.WriteLine("3 - Gerenciar Vendas.");
                Console.WriteLine("4 - Sair.");
                Console.WriteLine("-----      ---      ------");

                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        int menuCliente = 0;

                        while (menuCliente != 5)
                        {
                            Console.WriteLine("----- MENU CLIENTE ------");
                            Console.WriteLine("");

                            Console.WriteLine("1 - Cadastrar Cliente.");
                            Console.WriteLine("2 - Buscar Cliente.");
                            Console.WriteLine("3 - Listar Clientes.");
                            Console.WriteLine("4 - Deletar Cliente.");
                            Console.WriteLine("5 - Sair.");

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");

                            menuCliente = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");

                            switch (menuCliente)
                            {
                                case 1:
                                    GerenciarClientes.AdicionarCliente(listaClientes); 
                                    break;
                                case 2:
                                    GerenciarClientes.ProcurarCliente(listaClientes);
                                    break;
                                case 3:
                                    GerenciarClientes.ListarClientes(listaClientes);
                                    break;
                                case 4: 
                                    GerenciarClientes.DeletarCliente(listaClientes, listaVenda);
                                    break;
                            }
                        }


                    break;


                    case 2:

                        int menuProduto = 0;

                        while (menuProduto != 5)
                        {

                            Console.WriteLine("----- MENU PRODUTO ------");
                            Console.WriteLine("");

                            Console.WriteLine("1 - Cadastrar Produto.");
                            Console.WriteLine("2 - Buscar Produto.");
                            Console.WriteLine("3 - Listar Produto.");
                            Console.WriteLine("4 - Deletar Produto.");
                            Console.WriteLine("5 - Sair.");

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");

                            menuProduto = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");

                            switch (menuProduto)
                            {
                                case 1:
                                    GerenciarProdutos.CadastrarProduto(listaProdutos);
                                    break;
                                case 2:
                                    GerenciarProdutos.ProcurarProduto(listaProdutos);
                                    break;
                                case 3:
                                    GerenciarProdutos.ListarProdutos(listaProdutos);
                                    break;
                                case 4:
                                    GerenciarProdutos.DeletarProduto(listaProdutos, listaVenda); 
                                    break;

                            }

                        }


                    break;

                    case 3:
                        int menuVendas = 0;

                        while (menuVendas != 5)
                        {

                            Console.WriteLine("----- MENU VENDAS ------");
                            Console.WriteLine("");

                            Console.WriteLine("1 - Nova Venda.");
                            Console.WriteLine("2 - Buscar Venda.");
                            Console.WriteLine("3 - Listar Venda.");
                            Console.WriteLine("4 - Total de Vendas.");
                            Console.WriteLine("5 - Sair.");

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");


                            menuVendas = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("");
                            Console.WriteLine("-----      ---      ------");
                            Console.WriteLine("");
                           
                            switch(menuVendas)
                            {
                               case 1:
                                    
                                    GerenciarVendas.NovaVenda(listaVenda, listaProdutos, listaClientes);
                                    
                                    break;
                                case 2:
                                    GerenciarVendas.BuscarVenda(listaVenda);
                                    break;
                                case 3:
                                    GerenciarVendas.ListarVendas(listaVenda);
                                    break;
                                case 4: 
                                    GerenciarVendas.TotalVenda(listaVenda);
                                    break;
                            }
                        }

                    break;
                }
            }
        }
    }
}
