using System;
using System.Collections.Generic;
using System.Text;
using ToDoList_WPF.Entitats;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace ToDoList_WPF.Servei
{
    class TascaServei
    {
        public static IEnumerable<TascaDades> GetAll()
        {
            MongoServei MS = new MongoServei("Tasca");
            List<TascaDades> result = MS.tascaCollection.AsQueryable<TascaDades>().ToList();

            return result;
        }

        public int Add(TascaDades tasca)
        {
            MongoServei MS = new MongoServei("Tasca");
            MS.tascaCollection.InsertOne(tasca);
            return 1;
        }

        public int Update(TascaDades tasca)
        {
            MongoServei MS = new MongoServei("Tasca");
            var filter = Builders<TascaDades>.Filter.Eq("_id", tasca._id);
            MS.tascaCollection.ReplaceOne(filter, tasca);
            return 1;
        }

        public int UpdateEstat(ObjectId codi, string estat)
        {
            MongoServei MS = new MongoServei("Tasca");
            var filter = Builders<TascaDades>.Filter.Eq("Codi", codi);
            var update = Builders<TascaDades>.Update.Set("estat", estat);
            MS.tascaCollection.UpdateOne(filter, update);
            return 1;
        }
        

        public int Delete(String id)
        {
            MongoServei MS = new MongoServei("Tasca");
            var result = MS.tascaCollection.DeleteOne(t => t._id == id);
            return (int)result.DeletedCount;
        }

        public TascaDades Get(String id)
        {
            MongoServei MS = new MongoServei("Tasca");
            List<TascaDades> result = MS.tascaCollection.AsQueryable().Where(t => t._id == id).ToList();
            return result[0];
        }


    }
}

