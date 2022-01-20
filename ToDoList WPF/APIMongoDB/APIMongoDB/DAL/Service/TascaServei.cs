using System;
using System.Collections.Generic;
using System.Text;
using APIMongoDB.DAL.Model;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace APIMongoDB.DAL.Service
{
    public class TascaServei
    {
        public static IEnumerable<Tasca> GetAll()
        {
            MongoServei MS = new MongoServei("Tasca");
            List<Tasca> result = MS.tascaCollection.AsQueryable<Tasca>().ToList();

            return result;
        }

        public int Add(Tasca tasca)
        {
            MongoServei MS = new MongoServei("Tasca");
            MS.tascaCollection.InsertOne(tasca);
            return 1;
        }

        public int Update(Tasca tasca, String titol)
        {
            MongoServei MS = new MongoServei("Tasca");
            var filter = Builders<Tasca>.Filter.Eq("Titol", titol);
            MS.tascaCollection.ReplaceOne(filter, tasca);
            return 1;
        }

        public int UpdateEstat(string titol, string estat)
        {
            MongoServei MS = new MongoServei("Tasca");
            var filter = Builders<Tasca>.Filter.Eq("Titol", titol);
            var update = Builders<Tasca>.Update.Set("estat", estat);
            MS.tascaCollection.UpdateOne(filter, update);
            return 1;
        }


        public int Delete(string titol)
        {
            MongoServei MS = new MongoServei("Tasca");
            var result = MS.tascaCollection.DeleteOne(t => t.Titol == titol);
            return (int)result.DeletedCount;
        }

        public Tasca Get(string titol)
        {
            MongoServei MS = new MongoServei("Tasca");
            List<Tasca> result = MS.tascaCollection.AsQueryable().Where(t => t.Titol == titol).ToList();
            return result[0];
        }
    }
}
