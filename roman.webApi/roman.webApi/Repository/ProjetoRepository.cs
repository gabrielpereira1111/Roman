using roman.webApi.Contexts;
using roman.webApi.Domains;
using roman.webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        public Projeto BuscarPorId(int id)
        {
            return ctx.Projetos.FirstOrDefault(projeto => projeto.IdProjeto == id);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Projeto> ListarTudo()
        {
            return ctx.Projetos.ToList();
        }
    }
}
