﻿using System;
using System.Collections.Generic;

#nullable disable

namespace roman.webApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdTema { get; set; }
        public string Tema1 { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
