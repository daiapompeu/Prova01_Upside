using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questao04.MVC.Models
{
    public class EnviarDadosAPIViewModel
    {
        [Required(ErrorMessage = "Favor preencher o campo Nome.")]
        [Display(Name = "Nome:")]
        [JsonProperty(PropertyName = "firstname")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo CPF.")]
        [Display(Name = "CPF:")]
        [JsonProperty(PropertyName = "cad_cpf")]
        public String CPF { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo Data de Nascimento.")]
        [Display(Name = "Data de Nascimento:")]
        [JsonProperty(PropertyName = "cad_datanascimento")]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Favor preencher o campo E-mail.")]
        [Display(Name = "E-mail:")]
        [JsonProperty(PropertyName = "emailaddress1")]
        public String Email { get; set; }
    }
}