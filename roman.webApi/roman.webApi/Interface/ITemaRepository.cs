using roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Interface
{
    interface ITemaRepository
    {
        List<Tema> ListarTudo();
        void Cadastrar(Tema novoTema);
        void Deletar(int id);
        Tema BuscaPorId(int id);
    }
}
