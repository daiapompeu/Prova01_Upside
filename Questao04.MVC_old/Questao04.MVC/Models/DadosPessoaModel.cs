using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questao04.MVC.Models
{
    public class DadosPessoaModel
    {
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Favor preencher o campo Nome.")]
        [Display(Name = "Nome:")]
        [MaxLength(50)]
        public String Nome { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Favor preencher o campo CPF.")]
        [Display(Name = "CPF:")]
        [MaxLength(20)]
        public String CPF { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Favor preencher o campo Data de Nascimento.")]
        [Display(Name = "Data de Nascimento:")]
        [MaxLength(10)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Favor preencher o campo E-mail.")]
        [Display(Name = "E-mail:")]
        [MaxLength(50)]
        public String Email { get; set; }
    }
}