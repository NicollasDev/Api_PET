using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPET.Repositories;
using Microsoft.AspNetCore.Mvc;
using ApiPET.Domains;
using ApiPET.Context;

namespace ApiPET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPets : ControllerBase
    {
       
        TiposPetsRepository repo = new TiposPetsRepository();


        [HttpGet]
        public List<TiposPets> Get()
        {
            return repo.LerTodos();
        }


        [HttpGet("{id}")]
        public TiposPets Get(int id)
        {
            return repo.BuscarPorId(id);
        }


        [HttpPost]
        public TiposPets Post([FromBody] TiposPets tp)
        {
            return repo.Cadastrar(tp);
        }


        [HttpPut("{id}")]
        public TiposPets Put(int id, [FromBody] TiposPets tp)
        {
            return repo.Alterar(id, tp);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}