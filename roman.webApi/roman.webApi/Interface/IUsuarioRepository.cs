using roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Interface
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTudo();
        void Cadastrar(Usuario novoUsuario);
        Usuario BuscarPorId(int id);
        void Deletar(int id);
        Usuario Login(string email, string senha);
    }
}
