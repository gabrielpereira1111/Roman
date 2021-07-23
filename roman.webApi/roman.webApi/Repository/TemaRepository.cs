using roman.webApi.Contexts;
using roman.webApi.Domains;
using roman.webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Repository
{
    public class TemaRepository : ITemaRepository
    {
        RomanContext ctx = new RomanContext();

        public Tema BuscaPorId(int id)
        {
            return ctx.Temas.FirstOrDefault(tema => tema.IdTema == id);
        }

        public void Cadastrar(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Temas.Remove(BuscaPorId(id));
            ctx.SaveChanges();
        }

        public List<Tema> ListarTudo()
        {
            return ctx.Temas.ToList();
        }
    }
}
