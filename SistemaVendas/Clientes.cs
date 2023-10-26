using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaVendas
{
    internal class Clientes 
    {
        public int codigo {  get; set; }
        public String nome { get; set; }
        public int idade { get; set; }
        public String cpf { get; set; }



        public void AdicionarCliente(List<Clientes> listaClientes)
        {
            Console.WriteLine("----- CADASTRO DE CLIENTE -----");
            Console.WriteLine("Digite seu Código: ");
            codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite seu Nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite sua Idade: ");
            idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite seu CPF: ");
            cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("----- --- -----");
            Console.WriteLine("");

            Clientes cliente = new Clientes
            {
                codigo = codigo,
                nome = nome,
                idade = idade,
                cpf = cpf
            };
            listaClientes.Add(cliente);
        }


        public Clientes BuscarCliente(int cod, List<Clientes> listaClientes)
        {
            foreach (Clientes cliente in listaClientes)
            {
                if (cod == cliente.codigo)
                   return cliente;
            }
            return null;
        }

        public void ListarClientes(List<Clientes> listaClientes)
        {
            if (listaClientes.Count > 0)
            {
                Console.WriteLine("### LISTA DE CLIENTES ###");
                foreach (Clientes cliente in listaClientes)
                {

                    ExibirCliente(cliente);
                    Console.WriteLine("");
                    Console.WriteLine("################");
                    Console.WriteLine("");
                }
            }
            else
                Console.WriteLine("Lista Vazia!");


        }

        public void DeletarCliente(List<Clientes> listaClientes, List<Venda> listaVenda)
        {
            if (listaClientes.Count > 0)
            {
                Clientes removeCliente = null;
                int codigo;
                Console.WriteLine("Digite o Codigo do Cliente");
                codigo = Convert.ToInt32(Console.ReadLine());

                removeCliente = BuscarCliente(codigo, listaClientes);

                if (removeCliente != null)
                {
                    bool inVenda = false;
                    Clientes c = new Clientes();
                    foreach (Venda venda in listaVenda)
                    {
                        c = venda.clienteVenda;
                        if (codigo == c.codigo)
                            inVenda = true;
                    }

                    if (inVenda == false)
                    {
                        listaClientes.Remove(removeCliente);
                        Console.WriteLine("Cliente Removido");
                    }
                    else
                    {
                        Console.WriteLine(" --- --- ---");
                        Console.WriteLine("O Cliente nao foi removido pois ele esta em uma compra!");
                        Console.WriteLine(" --- --- ---");
                    }
                }
                else
                    Console.WriteLine("Não há clientes cadastrados!");
            }
            else
               Console.WriteLine("Lista vazia!");
        }

        public void ExibirCliente(Clientes c)
        {
            Console.WriteLine(c.codigo);
            Console.WriteLine(c.nome);
            Console.WriteLine(c.idade);
            Console.WriteLine(c.cpf);
        }

        public void ProcurarCliente(List<Clientes> listaClientes)
        {
            if (listaClientes.Count == 0)
                Console.WriteLine("Não há clientes cadastrados!");
            else
            {
                Clientes i;
                int Codbusca;

                Console.Out.WriteLine("Digite o Codigo do Cliente: ");
                Codbusca = Convert.ToInt32(Console.ReadLine());

                i = BuscarCliente(Codbusca, listaClientes);

                if (i != null)
                {
                    Console.WriteLine("----- INFORMACOES DO CLIENTE -----");
                    ExibirCliente(i);
                    Console.WriteLine("");
                    Console.WriteLine("------------------");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Cliente nao Encontrado!");
                }
            }
        }
    }

 
}