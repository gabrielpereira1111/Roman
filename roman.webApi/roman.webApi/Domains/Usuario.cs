using System;
using System.Collections.Generic;

#nullable disable

namespace roman.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Senha { get; set; }
        public int? IdTipo { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
