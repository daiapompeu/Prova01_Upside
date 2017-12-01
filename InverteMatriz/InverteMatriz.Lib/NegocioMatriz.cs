using InverteMatriz.Lib.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverteMatriz.Lib
{
    public class NegocioMatriz
    {
        /// <summary>
        /// Retornar Matriz Transposta - Transposição de linhas por colunas 
        /// </summary>
        /// <param name="matrizInverter"></param>
        /// <returns></returns>
        public EstruturaMatrizTransposta RetornaMatrizTransposta(int[,] matrizInverter)
        {
            int l = matrizInverter.GetLength(0);
            int c = matrizInverter.GetLength(1);
            int[,] matrizTransposta = new int[c,l];

            try
            {
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        matrizTransposta[j, i] = matrizInverter[i, j];
                    }
                }
            }
            catch (Exception ex)
            {
                return new EstruturaMatrizTransposta { IndicadorErro = 1, DescricaoErro = String.Format("Erro ao processar transposição de matriz - Detalhes: {0}", ex.Message) };
            }

            return new EstruturaMatrizTransposta { MatrizTransposta = matrizTransposta };
        }
    }
}
