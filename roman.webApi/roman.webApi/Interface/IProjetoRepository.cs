using roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Interface
{
    interface IProjetoRepository
    {
        List<Projeto> ListarTudo();
        void Cadastrar(Projeto novoProjeto);
        void Deletar(int id);
        Projeto BuscarPorId(int id);
    }
}
