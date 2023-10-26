namespace SistemaVendas
{
    interface Icliente
    {
        void AdicionarCliente();
        Clientes BuscarCliente(int cod);
        void ListarCliente();
        void DeletarCliente();
    }

    interface Iproduto
    {
        void CadastrarProduto();
        Produtos BuscarProduto(int cod);
        void ListarProduto();   
        void DeletarProduto();
    }

    interface IVenda
    {

    }
}