using APIMongoDB.DAL.Model;
using APIMongoDB.DAL.Service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMongoDB.Controllers
{
    [Route("api/treballador")]
    [ApiController]
    public class TreballadorController : ControllerBase
    {
        [HttpGet]
        public List<Treballador> Get()
        {
            return TreballadorServei.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Treballador Get(String id)
        {
            TreballadorServei ts = new TreballadorServei();
            return ts.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Treballador treballador)
        {
            TreballadorServei tb = new TreballadorServei();
            tb.Add(treballador);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Treballador treballador, String id)
        {
            TreballadorServei ts = new TreballadorServei();
            ts.Update(treballador, id);
        }

        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            TreballadorServei ts = new TreballadorServei();
            ts.Delete(id);
        }
    }
}
