using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreClientSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            SoapClient c = new SoapClient();

            c.Start();


            Console.ReadKey();
        }
    }
}
