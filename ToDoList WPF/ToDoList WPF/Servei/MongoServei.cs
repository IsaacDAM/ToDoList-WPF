using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using ToDoList_WPF.Entitats;

namespace ToDoList_WPF.Servei
{
    class MongoServei
    {
        private MongoClient mongoClient;
        public IMongoCollection<TascaDades> tascaCollection { get; set; }
        public IMongoCollection<TreballadorDades> treballadorCollection { get; set; }
        public MongoServei(string collection)
        {
            mongoClient = new MongoClient("mongodb+srv://ToDoList:tdlpwd@cluster2021.pqnkq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = mongoClient.GetDatabase("ToDoList");
            if (collection == "Treballador")
            {
                treballadorCollection = database.GetCollection<TreballadorDades>(collection);
                tascaCollection = null;
            }
            else if(collection == "Tasca")
            {
                tascaCollection = database.GetCollection<TascaDades>(collection);
                treballadorCollection = null;
            }
        }

    }
}
