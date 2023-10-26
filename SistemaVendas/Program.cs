using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SistemaVendas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gerenciador programa = new Gerenciador();
            programa.MenuPrincipal();
   
        }
    }
}
