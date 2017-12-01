using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConsole
{
    public class NumerosPrimos
    {
        #region[ Métodos ]

        /// <summary>
        /// Retornar números primos menores que um valor Limite.
        /// </summary>
        /// <param name="valorLimite">Valor limite para obtenção de números</param>
        public List<int> ObterNumerosPrimos(int valorLimite)
        {
            List<int> listaNumeros = new List<int>();
            try
            {
                for (int i = 1; i < valorLimite; i += 2)
                {
                    switch (i)
                    {
                        case 1:                            
                            break;
                        case 2:
                            listaNumeros.Add(2);
                            break;
                        case 3:
                            listaNumeros.Add(3);
                            break;
                        default:
                            if (IsNumeroPrimo(i))
                            {
                                listaNumeros.Add(i);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Erro ao obter Números Primos - Detalhes: {0}", ex.Message));
            }

            return listaNumeros;
        }

        private bool IsNumeroPrimo(int numeroValidar)
        {
            for (int i = 3; i < numeroValidar; i+=2)
            {
                if (numeroValidar % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
