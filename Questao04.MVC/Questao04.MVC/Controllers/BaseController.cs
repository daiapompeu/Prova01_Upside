using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Questao04.MVC.Models;

namespace Questao04.MVC.Controllers
{
    public class BaseController : Controller
    {
        internal void MensagemSucesso(string mensagem)
        {
            TempData["AlertaSucesso"] = mensagem;
        }

        internal static bool VerificaCPFValido(string cpfValidar)
        {
            int[] arrayAux = null;
            int Sum = 0;
            int digitoVerificador01 = 0;
            int digitoVerificador02 = 0;

            if (string.IsNullOrEmpty(cpfValidar))
            {
                return true;
            }

            cpfValidar = Regex.Replace(cpfValidar, "[^0-9a-zA-Z]+", "");

            if (long.Parse(cpfValidar) == 0)
            {
                return false;
            }

            if (cpfValidar.Length != 11)
            {
                cpfValidar = string.Format("{ 0:D11}", long.Parse(cpfValidar));
            }

            arrayAux = new int[11];
            for (int x = 0; x < arrayAux.Length; x++)
            {
                arrayAux[x] = int.Parse(cpfValidar[x].ToString());
            }

            Sum = 0;
            for (int x = 1; x <= 9; x++)
            {
                Sum += arrayAux[x - 1] * (11 - x);
            }

            Math.DivRem(Sum, 11, out digitoVerificador01);
            digitoVerificador01 = 11 - digitoVerificador01; digitoVerificador01 = digitoVerificador01 > 9 ? 0 : digitoVerificador01;

            if (digitoVerificador01 != arrayAux[9])
            {
                return false;
            }

            Sum = 0;
            for (int x = 1; x <= 10; x++)
            {
                Sum += arrayAux[x - 1] * (12 - x);
            }

            Math.DivRem(Sum, 11, out digitoVerificador02);
            digitoVerificador02 = 11 - digitoVerificador02;
            digitoVerificador02 = digitoVerificador02 > 9 ? 0 : digitoVerificador02;

            if (digitoVerificador02 != arrayAux[10])
            {
                return false;
            }

            return true;
        }

        internal DistribuirCandidatosViewModel DistribuirAlunos(string dadosArquivo)
        {
            try
            {
                List<CandidatoModel> listaCandidatosEnsalamento = new List<CandidatoModel>();
                List<CandidatoModel> listaCandidatosSobra = new List<CandidatoModel>();

                String[] arrayDados = dadosArquivo.Split('\n');
                arrayDados = arrayDados.Skip(1).ToArray();

                foreach (string row in arrayDados)
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        listaCandidatosEnsalamento.Add(new CandidatoModel
                        {
                            NomeCompleto = row.Split(';')[0],
                            Sexto = row.Split(';')[1],
                            Afinidade = Convert.ToInt32(row.Split(';')[2])
                        });
                    }
                }
                
                listaCandidatosEnsalamento = listaCandidatosEnsalamento.OrderBy(c => c.Afinidade).ToList();

                throw new InvalidOperationException("Requisitos Conflitantes");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
        
