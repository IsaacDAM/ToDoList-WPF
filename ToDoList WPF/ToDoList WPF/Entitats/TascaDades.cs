using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ToDoList_WPF.Entitats
{
    public class TascaDades
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }

        [BsonElement ("titol")]
        public String Titol { get; set; }

        [BsonElement("descripcio")]
        public String Descripcio { get; set; }

        [BsonElement("dcreacio")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime dCreacio { get; set; }

        [BsonElement("dfinalitzacio")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime dFinalitzacio { get; set; }

        [BsonElement("prioritat")]
        public String Prioritat { get; set; }

        [BsonElement("representant")]
        public String Representant { get; set; }

        [BsonElement("estat")]
        public String Estat { get; set; }

        public TascaDades(string titol, string descripcio, DateTime dcreacio, DateTime dfinalitzacio, string prioritat, string representant, string estat)
        {
            this.Titol = titol;
            this.Descripcio = descripcio;
            this.dCreacio = dcreacio;
            this.dFinalitzacio = dfinalitzacio;
            this.Prioritat = prioritat;
            this.Representant = representant;
            this.Estat = estat;
        }

        public TascaDades() { }

        /*public override string ToString()
        {
            return string.Format ("id: {0}\ntitol: {1}\ndescripcio: {2}\ndcreacio: {3}\ndfinalitzacio: {4}\nprioritat: {5}\nrepresentant: {6}\nestat: {7}\n", this.Codi, this.Titol, this.Descripcio, this.dCreacio.Date, this.dFinalitzacio.Date, this.Prioritat, this.Representant, this.Estat);
        }*/


    }
}
