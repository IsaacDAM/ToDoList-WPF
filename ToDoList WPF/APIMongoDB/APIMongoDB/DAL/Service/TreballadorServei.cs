﻿using System;
using System.Collections.Generic;
using APIMongoDB.DAL.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace APIMongoDB.DAL.Service
{
    public class TreballadorServei
    {
        public static IEnumerable<Treballador> GetAll()
        {
            MongoServei MS = new MongoServei("Treballador");
            List<Treballador> result = MS.treballadorCollection.AsQueryable<Treballador>().ToList();

            return result;
        }

        public int Add(Treballador treballador)
        {
            MongoServei MS = new MongoServei("Treballador");
            if (MS.treballadorCollection.AsQueryable<Treballador>().Where(t => t.NIF == treballador.NIF).ToList().Count == 0)
            {
                MS.treballadorCollection.InsertOne(treballador);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Update(Treballador treballador, String NIF)
        {
            MongoServei MS = new MongoServei("Treballador");
            if (MS.treballadorCollection.AsQueryable<Treballador>().Where(t => t.NIF == treballador.NIF).ToList().Count == 0 || treballador.NIF == NIF)
            {
                var filter = Builders<Treballador>.Filter.Eq("nif", NIF);
                MS.treballadorCollection.ReplaceOne(filter, treballador);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(Treballador treballador)
        {
            MongoServei MS = new MongoServei("Treballador");
            var result = MS.treballadorCollection.DeleteOne(t => t.NIF == treballador.NIF);
            return (int)result.DeletedCount;
        }
    }
}