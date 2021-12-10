using System;
using System.Collections.Generic;
using ToDoList_WPF.Entitats;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ToDoList_WPF.Servei
{
    class TreballadorServei
    {
        public static IEnumerable<TreballadorDades> GetAll()
        {
            MongoServei MS = new MongoServei("Treballador");
            List<TreballadorDades> result = MS.treballadorCollection.AsQueryable<TreballadorDades>().ToList();

            return result;
        }

        public int Add(TreballadorDades treballador)
        {
            MongoServei MS = new MongoServei("Treballador");
            if(MS.treballadorCollection.AsQueryable<TreballadorDades>().Where(t => t.NIF == treballador.NIF).ToList().Count == 0)
            {
                MS.treballadorCollection.InsertOne(treballador);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Update(TreballadorDades treballador, String NIF)
        {
            MongoServei MS = new MongoServei("Treballador");
            if(MS.treballadorCollection.AsQueryable<TreballadorDades>().Where(t => t.NIF == treballador.NIF).ToList().Count == 0 || treballador.NIF == NIF)
            {
                var filter = Builders<TreballadorDades>.Filter.Eq("nif", NIF);
                MS.treballadorCollection.ReplaceOne(filter, treballador);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(TreballadorDades treballador)
        {
            MongoServei MS = new MongoServei("Treballador");
            var result = MS.treballadorCollection.DeleteOne(t => t.NIF == treballador.NIF);
            return (int)result.DeletedCount;
        }
    }
}
