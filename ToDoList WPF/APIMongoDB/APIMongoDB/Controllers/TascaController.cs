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
        // GET: users
        [HttpGet]
        public List<Tasca> Get()
        {
            return TascaServei.GetAll().ToList();
        }

        // GET users/5
        [HttpGet("{id}")]
        public Tasca Get(ObjectId id)
        {
            TascaServei ts = new TascaServei();
            return ts.Get(id);
        }

        // POST users
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            TascaServei ts = new TascaServei();
            ts.Add(tasca);
        }

        // PUT users/5
        [HttpPut]
        public void Put(Tasca tasca)
        {
            TascaServei ts = new TascaServei();
            ts.Update(tasca);
        }

        // DELETE users/5
        [HttpDelete("{id}")]

        public void Delete(ObjectId id)
        {
            TascaServei ts = new TascaServei();
            ts.Delete(id);
        }

    }
}
