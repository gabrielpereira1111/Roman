using roman.webApi.Contexts;
using roman.webApi.Domains;
using roman.webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        RomanContext ctx = new RomanContext();
        public List<TipoUsuario> ListarTudo()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
