using Microsoft.EntityFrameworkCore;
using roman.webApi.Contexts;
using roman.webApi.Domains;
using roman.webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Select(usuario => new Usuario() { 
                IdUsuario = usuario.IdUsuario,
                Usuario1 = usuario.Usuario1,
                IdTipoNavigation = new TipoUsuario()
                {
                    IdTipo = usuario.IdTipoNavigation.IdTipo,
                    Tipo = usuario.IdTipoNavigation.Tipo
                }
            }).FirstOrDefault(usuario => usuario.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTudo()
        {
            return ctx.Usuarios.Include(usuario => usuario.Projetos).Select(usuario => new Usuario() {
                IdUsuario = usuario.IdUsuario,
                Usuario1 = usuario.Usuario1,
                IdTipoNavigation = new TipoUsuario()
                {
                    IdTipo = usuario.IdTipoNavigation.IdTipo,
                    Tipo = usuario.IdTipoNavigation.Tipo
                },
                Projetos = usuario.Projetos
            }).ToList();
        }

        public Usuario Login(string usuario, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Usuario1 == usuario && u.Senha == senha);

        }
    }
}
