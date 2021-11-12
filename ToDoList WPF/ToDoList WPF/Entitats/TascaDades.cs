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
        public enum _Prioritat { Alta, Mitja, Baixa }
        public _Prioritat Prioritat { get; set; }
        public string Representant { get; set; }
        public enum _Estat { ToDo, Doing, Done}
        public _Estat Estat { get; set; }
    }
}
