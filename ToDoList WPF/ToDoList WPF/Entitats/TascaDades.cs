using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList_WPF.Entitats
{
    class TascaDades
    {
        public int Codi { get; set; }
        public string Titol { get; set; }
        public string Descripcio { get; set; }
        public DateTime dCreacio { get; set; }
        public DateTime dFinalitzacio { get; set; }
        public string Prioritat { get; set; }
        public string Representant { get; set; }
        public string Estat { get; set; }
    }
}
