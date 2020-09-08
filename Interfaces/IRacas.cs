using ApiPET.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPET.Interfaces
{
    interface IRacas
    {
        Racas Cadastrar(Racas r);
        List<Racas> LerTodos();
        Racas BuscarPorId(int id);
        Racas Alterar(int id, Racas r);
        void Excluir(int id);
    }
}