using roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTudo();
    }
}
