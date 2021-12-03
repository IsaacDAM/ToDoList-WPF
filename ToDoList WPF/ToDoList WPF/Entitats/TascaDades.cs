using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ToDoList_WPF.Entitats
{
    public class TascaDades
    {
        public int Codi { get; set; }
        public String Titol { get; set; }
        public String Descripcio { get; set; }
        public DateTime dCreacio { get; set; }
        public DateTime dFinalitzacio { get; set; }
        public String Prioritat { get; set; }
        public String Representant { get; set; }
        public String Estat { get; set; }
    }
}
