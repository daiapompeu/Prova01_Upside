using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region [ Números Primos ]

            List<int> listaRetorno = new NumerosPrimos().ObterNumerosPrimos(100);
            Console.WriteLine(String.Format("Os números primos menores que 100 são: {0}", String.Join(", ", listaRetorno)));
            System.Console.ReadLine();

            #endregion

            #region[ Verifica item Vetor Ordenado ]

            VetorOrdenado classeVetor = new VetorOrdenado();
            classeVetor.ArrayInteirosOrdenados = new int[10] { 25, 26, 27, 28, 29, 30, 34, 32, 33, 34 };
            Array.Sort(classeVetor.ArrayInteirosOrdenados);
            Boolean valorExistente = classeVetor.VerificaItemVetor(9);
            valorExistente = classeVetor.VerificaItemVetor(25);
            valorExistente = classeVetor.VerificaItemVetor(27);

            #endregion            
        }
    }
}
