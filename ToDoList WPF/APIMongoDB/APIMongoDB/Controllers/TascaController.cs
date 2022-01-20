using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMongoDB.DAL.Service;
using APIMongoDB.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace APIMongoDB.Controllers
{
    [Route("api/tasca")]
    [ApiController]
    public class TascaController
    {
        // GET tasques
        [HttpGet]
        public List<Tasca> Get()
        {
            return TascaServei.GetAll().ToList();
        }

        // GET tasca
        [HttpGet("{id}")]
        public Tasca Get(string id)
        {
            TascaServei ts = new TascaServei();
            return ts.Get(id);
        }

        // POST tasca
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            TascaServei ts = new TascaServei();
            ts.Add(tasca);
        }

        // PUT tasca
        [HttpPut]
        public void Put(Tasca tasca, String titol)
        {
            TascaServei ts = new TascaServei();
            ts.Update(tasca,titol);
        }

        // DELETE tasca
        [HttpDelete("{id}")]

        public void Delete(string id)
        {
            TascaServei ts = new TascaServei();
            ts.Delete(id);
        }

    }
}
