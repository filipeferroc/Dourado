using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas
{
    internal class Produtos
    {
        public int codigo { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String descricao { get; set; }
        public double preco;


        public void CadastrarProduto(List<Produtos> listaProdutos)
        {
            Console.WriteLine("----- CADASTRO DE PRODUTO -----");
            Console.WriteLine("");
            Console.WriteLine("Digite o Codigo: ");
            codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a Marca: ");
            marca = Console.ReadLine();
            Console.WriteLine("Digite o Modelo: ");
            modelo = Console.ReadLine();
            Console.WriteLine("Digite a Descricao: ");
            descricao = Console.ReadLine();
            Console.WriteLine("Digite o Preco: ");
            preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("----- --- -----");
            Console.WriteLine("");

            Produtos produto = new Produtos
            {
                codigo = codigo,
                marca = marca,
                modelo = modelo,
                descricao = descricao,
                preco = preco
            };
            listaProdutos.Add(produto);
        }

        public Produtos BuscarProduto(int cod, List<Produtos> listaProdutos)
        {
            foreach (Produtos produto in listaProdutos)
            {
                if (cod == produto.codigo)
                    return produto;
            }
            return null;

        }

        public void ListarProdutos(List<Produtos> listaProdutos)
        {
            if (listaProdutos.Count > 0)
            {
                Console.WriteLine("----- LISTA DE PRODUTOS -----");
                foreach (Produtos produto in listaProdutos)
                {
                    ExibirProduto(produto);
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

        public void DeletarProduto(List<Produtos> listaProdutos, List<Venda> listaVendas)
        {
            
            if(listaProdutos.Count > 0)
            {
                Produtos removeProduto = null;
                int codigo;
                Console.WriteLine("Digite o Codigo do Produto:");
                codigo = Convert.ToInt32(Console.ReadLine());

                removeProduto = BuscarProduto(codigo, listaProdutos);

                if (removeProduto != null)
                {
                    bool inVenda = false;
                    foreach (Venda v in listaVendas)
                    {
                        foreach (Produtos produtos in v.ListaPorVenda)
                        {
                            if (codigo == produtos.codigo)
                            {
                                inVenda = true;
                                break;
                            }

                        }
                    }
                    if(inVenda == false)
                    {
                        listaProdutos.Remove(removeProduto);
                        Console.WriteLine("Produto Removido!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" --- --- ---");
                        Console.WriteLine("O Produto nao foi removido pois ele esta em uma compra!");
                        Console.WriteLine(" --- --- ---");
                    }
                        
                    
                }else
                    Console.WriteLine("Produto nao encontrado!");
            }
            else
                Console.WriteLine("Lista Vazia!");

        }

        public void ExibirProduto(Produtos p)
        {
            Console.WriteLine(p.codigo);
            Console.WriteLine(p.marca);
            Console.WriteLine(p.modelo);
            Console.WriteLine(p.descricao);
            Console.WriteLine(p.preco);
        }

        public void ProcurarProduto(List<Produtos> listaProdutos)
        {
            if (listaProdutos.Count == 0)
                Console.WriteLine("Lista Vazia");
            else
            {
                Produtos p;
                int codigoBusca;

                Console.WriteLine("Digite o Codigo do Produto:");
                codigoBusca = Convert.ToInt32(Console.ReadLine());

                p = BuscarProduto(codigoBusca, listaProdutos);

                if (p != null)
                {
                    ExibirProduto(p);
                    Console.WriteLine("");
                    Console.WriteLine("------ --- ------");
                    Console.WriteLine("");
                }
                else
                    Console.WriteLine("Produto Não Encontrado");
            }
        }
    }
}
