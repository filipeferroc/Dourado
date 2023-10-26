using SistemaVendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SistemaVendas
{
    internal class Venda
    {
        
        public int codigoVenda = 1;

        public Clientes clienteVenda;
        
        public List<Produtos> ListaPorVenda;
        public double total;



        public void NovaVenda(List<Venda> listaVenda, List<Produtos> listaProdutos, List<Clientes> listaClientes)
        {

            List<Produtos> ListaProdutosVenda = new List<Produtos>();
            int codCliente = 77;
            int codProduto = 77;

            Console.WriteLine("----- NOVA VENDA -----");
            Console.WriteLine("");
            
            bool sair = false;
            Clientes auxC = null;
            Produtos auxP = null;

            Console.WriteLine("Informe o codigo do cliente (ou 0 para encerrar):");
            codCliente = Convert.ToInt32(Console.ReadLine());

            foreach (Clientes cliente in listaClientes)
            {
                if (codCliente == cliente.codigo)
                {
                    auxC = cliente;
                }
            }

            if (auxC == null)
                Console.WriteLine("Cliente não existe");
            else
            {
                do
                {
                    Console.WriteLine("Informe o codigo do produto (ou 0 para encerrar):");
                    codProduto = Convert.ToInt32(Console.ReadLine());

                    if (codProduto == 0)
                    {
                        sair = true;
                    }

                    if (sair == false)
                    {
                        auxP = listaProdutos.Find(produto => produto.codigo == codProduto);

                        if (auxP == null)
                        {
                            Console.WriteLine("Produto não existe");
                        }
                        else
                        {
                            ListaProdutosVenda.Add(auxP);

                        }
                    }
                    
                } while (sair == false);

            }


            

            double totalProdutos = 0.0;
            foreach (Produtos produto in ListaProdutosVenda)
            {
                totalProdutos += produto.preco;
            }

            Venda venda = new Venda
            {
                codigoVenda = codigoVenda++,
                clienteVenda = auxC,
                ListaPorVenda = new List<Produtos>(ListaProdutosVenda),
                total = totalProdutos

            };
            listaVenda.Add(venda);

            ListaProdutosVenda.Clear();
        }

        public void ListarVendas(List<Venda> listaVendas)
        {
            if (listaVendas.Count > 0)
            {
                Console.WriteLine("----- LISTA DE VENDAS -----");
                foreach (Venda listvenda in listaVendas)
                {
                    ExibirVenda(listvenda);
                    Console.WriteLine("");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Lista Vazia!");
                Console.WriteLine("");
                Console.WriteLine("------------------");
                Console.WriteLine("");
            }
        }

        public void ExibirVenda(Venda v)
        {

            Console.WriteLine("Codigo da Venda: {0}", v.codigoVenda);
            Console.WriteLine("Codigo do Cliente: {0}", v.clienteVenda.codigo);
            Console.WriteLine("Total da Venda: {0}", v.total);

            
        }


        public void BuscarVenda(List<Venda> listaVenda)
        {
            Venda  auxV = new Venda();

            if(listaVenda.Count == 0)
            {
                Console.WriteLine("Lista Vazia!");
            }
            else
            {
                int codVenda;
                Console.WriteLine("Digite o codigo da Venda: ");
                codVenda = Convert.ToInt32(Console.ReadLine());

                auxV = listaVenda.Find(venda => venda.codigoVenda == codVenda);

                if(auxV != null)
                {
                    Console.WriteLine("----- INFORMACOES DA VENDA -----");
                    ExibirVenda(auxV);
                    Console.WriteLine("");
                    Console.WriteLine("------------------");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Venda não encontra!");
                }
            }
        }

        public void TotalVenda(List<Venda> listaVendas)
        {
            double totalVenda = 0;
            foreach (Venda v in listaVendas)
            {
                foreach (Produtos produtos in v.ListaPorVenda)
                {
                    totalVenda += produtos.preco;

                }
            }
            Console.WriteLine("Total de todas as vendas: {0}", totalVenda);
        }

    }
}