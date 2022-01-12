using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using APIMongoDB.DAL.Model;

namespace APIMongoDB.DAL.Service
{
    public class MongoServei
    {
        private MongoClient mongoClient;
        public IMongoCollection<Tasca> tascaCollection { get; set; }
        public IMongoCollection<Treballador> treballadorCollection { get; set; }
        public MongoServei(string collection)
        {
            mongoClient = new MongoClient("mongodb+srv://ToDoList:tdlpwd@cluster2021.pqnkq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = mongoClient.GetDatabase("ToDoList");
            if (collection == "Treballador")
            {
                treballadorCollection = database.GetCollection<Treballador>(collection);
                tascaCollection = null;
            }
            else if (collection == "Tasca")
            {
                tascaCollection = database.GetCollection<Tasca>(collection);
                treballadorCollection = null;
            }
        }
    }
}
