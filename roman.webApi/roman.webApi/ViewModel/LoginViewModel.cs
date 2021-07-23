using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o seu nome de usuário!")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Informe a sua senha")]
        public string senha { get; set; }
    }
}
