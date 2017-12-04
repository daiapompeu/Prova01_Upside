using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questao04.MVC.Models
{
    public class SalaModel
    {
        public int Afinidade { get; set; }
        public int Capacidade { get; set; }
        public String NomeSala { get; set; }
        public List<CandidatoModel> ListaCandidatos { get; set; }
    }
}