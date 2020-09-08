using ApiPET.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPET.Interfaces
{
    interface ITiposPets
    {
        TiposPets Cadastrar(TiposPets tp);
        List<TiposPets> LerTodos();
        TiposPets BuscarPorId(int id);
        TiposPets Alterar(int id, TiposPets tp);
        void Excluir(int id);
    }
}