﻿using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APIMongoDB.DAL.Model
{
    public class Treballador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }


        [BsonElement("nif")]
        public String NIF { get; set; }

        [BsonElement("nom")]
        public String Nom { get; set; }

        [BsonElement("cognoms")]
        public String Cognoms { get; set; }

        [BsonElement("telefon")]
        public String Telefon { get; set; }

        [BsonElement("correu")]
        public String Correu { get; set; }


        public Treballador(string nif, string nom, string cognoms, string telefon, string correu)
        {
            this.NIF = nif;
            this.Nom = nom;
            this.Cognoms = cognoms;
            this.Telefon = telefon;
            this.Correu = correu;

        }

        public Treballador() { }

        /*public override string ToString()
        {
            return String.Format("id: {0}\nNIF: {1}\nnom: {2}\ncognoms: {3}\ntelefon: {4}\ncorreu: {5}\n", this.CodiT, this.NIF, this.Nom, this.Cognoms, this.Telefon, this.Correu);
        }*/
    }
}
