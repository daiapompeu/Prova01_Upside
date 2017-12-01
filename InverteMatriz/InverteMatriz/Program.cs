using InverteMatriz.Lib;
using InverteMatriz.Lib.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverteMatriz.Console
{
    class Program
    {
        /// <summary>
        /// Recebe via Comand Line a Matriz a ser Transposta - Formato Json - Exemplo: [[10,20,30],[40,50,60],[70,80,90]]
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region[ Inverter Matriz ]

            try
            {
                String cadeiaMatriz = args[0];
                int[,] matrizInverter = Newtonsoft.Json.JsonConvert.DeserializeObject<int[,]>(cadeiaMatriz);

                EstruturaMatrizTransposta estruturaRetorno = new NegocioMatriz().RetornaMatrizTransposta(matrizInverter);

                if (estruturaRetorno.IndicadorErro == 0)
                {
                    System.Console.WriteLine(String.Format("Matriz Original: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(matrizInverter)));
                    System.Console.WriteLine(String.Format("Matriz Transposta: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(estruturaRetorno.MatrizTransposta)));
                    System.Console.ReadLine();
                    System.Environment.Exit(0);
                }
                else
                {
                    System.Console.WriteLine(estruturaRetorno.DescricaoErro);
                    System.Console.ReadLine();
                    System.Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(String.Format("Exceção ao executar o Console - Detalhes: {0}", ex.Message));
                System.Console.ReadLine();
                System.Environment.Exit(1);
            }

            #endregion
        }
    }
}
