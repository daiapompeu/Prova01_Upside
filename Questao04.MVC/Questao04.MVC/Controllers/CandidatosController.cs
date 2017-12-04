using Questao04.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Questao04.MVC.Controllers
{
    public class CandidatosController : BaseController
    {
        // GET: Candidatos
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DistribuirCandidatos()
        {
            DistribuirCandidatosViewModel model = new DistribuirCandidatosViewModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }                

                if(Request.Files.Count > 0)
                {
                    HttpPostedFileBase arquivoCandidatos = Request.Files[0];
                    String extensao = Path.GetExtension(arquivoCandidatos.FileName);

                    if (extensao != ".csv")
                    {
                        ModelState.AddModelError(string.Empty, string.Format("Arquivo: {0}, com extensão: {1} está fora do formato aceito (.csv).", arquivoCandidatos.FileName, extensao));
                        return View("Index");
                    }

                    BinaryReader binaryReader = new BinaryReader(arquivoCandidatos.InputStream);
                    byte[] binData = binaryReader.ReadBytes(arquivoCandidatos.ContentLength);
                    string dadosArquivo = System.Text.Encoding.UTF8.GetString(binData);

                    model = base.DistribuirAlunos(dadosArquivo);

                    if(model.IndicadorErro != 0)
                    {
                        ModelState.AddModelError(string.Empty, String.Format("Erro ao distribuir candidatos nas salas - Detalhes: {0}", model.DescricaoErro));
                        return View("Index");
                    }

                    base.MensagemSucesso("Sucesso ao distribuir alunos.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nenhum arquivo selecionado.");
                    return View("Index");
                }

                base.MensagemSucesso("Sucesso ao processar dados.");
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, String.Format("Erro ao processar dados - Detalhes: {0}", ex.Message));
            }

            return View("Index", model);
        }
    }
}