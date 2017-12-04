using System;
using System.Web.Mvc;
using Questao04.MVC.Models;
using System.Net.Http;
using System.Text;

namespace Questao04.MVC.Controllers
{
    public class EnviarDadosAPIController : BaseController
    {
        // GET: EnviarDadosAPI
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarDadosAPI(EnviarDadosAPIViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }

                if(!VerificaCPFValido(model.CPF))
                {
                    ModelState.AddModelError(string.Empty, "Digite um CPF válido!");
                    return View("Index");
                }

                var client = new HttpClient();
                var postData = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");

                client.PostAsync("http://fichainscricaodesenv.azurewebsites.net/integracao.aspx", content).ContinueWith(
                    (postTask) =>
                    {
                        postTask.Result.EnsureSuccessStatusCode();
                    });

                base.MensagemSucesso("Sucesso ao enviar dados.");
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, String.Format("Erro ao enviar dados API - Detalhes: {0}", ex.Message));
            }

            return View("Index");
        }
    }
}