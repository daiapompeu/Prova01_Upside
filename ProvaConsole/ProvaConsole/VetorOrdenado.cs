using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConsole
{
    public class VetorOrdenado
    {
        #region [ Propriedades ]
        public int[] ArrayInteirosOrdenados { get; set; }

        #endregion

        #region[ Métodos ]
        /// <summary>
        /// Utilizar Busca Binária para busca de Elemento em Vetor Ordenado
        /// </summary>
        /// <param name="numeroVerificar">Número a ser encontrado no vetor</param>
        /// <returns></returns>
        public bool VerificaItemVetor(Int32 numeroVerificar)
        {
            int metade;
            int minimo = 0;
            int tamanho = ArrayInteirosOrdenados.Length - 1;

            do
            {
                metade = (int)(minimo + tamanho) / 2;
                if (ArrayInteirosOrdenados[metade] == numeroVerificar)
                {
                    return true;
                }
                else if (numeroVerificar >= ArrayInteirosOrdenados[metade])
                {
                    minimo = metade + 1;
                }
                else
                {
                    tamanho = metade - 1;
                }
            }
            while (minimo <= tamanho);

            return false;
        }
        #endregion

    }
}
