using ApiPET.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Racas : ControllerBase
    {

        
        RacasRepository repo = new RacasRepository();

        
        [HttpGet]
        public List<Racas> Get()
        {
            return repo.LerTodos();
        }

       
        [HttpGet("{id}")]
        public Racas Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        
        [HttpPost]
        public Racas Post([FromBody] Racas r)
        {
            return repo.Cadastrar(r);
        }

        
        [HttpPut("{id}")]
        public Racas Put(int id, [FromBody] Racas r)
        {
            return repo.Alterar(id, r);
        }

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}