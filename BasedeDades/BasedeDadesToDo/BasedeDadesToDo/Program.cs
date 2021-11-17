using System;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Persistence;
using ToDoList_WPF.Servei;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToDoList_WPF
{
    class EmplenarBDD
    {
        static void Main(string[] args)
        {
            DbContext.Up();

            foreach (var tasca in TascaServei.GetAll())
            {
                Console.WriteLine(
                    string.Format("#{0}: - Titol: {1}, Descripcio: {2}, DataCreacio: {3}, DataFinalitzacio: {4}, Prioritat: {5}, Representant: {6}, Estat: {7} ", tasca.Codi, tasca.Titol, tasca.Descripcio, tasca.dCreacio, tasca.dFinalitzacio, tasca.Prioritat, tasca.Representant, tasca.Estat)
                );
            }
            foreach (var treballador in TreballadorServei.GetAll())
            {
                Console.WriteLine(
                    string.Format("NIF: {0} - Nom: {1}, Cognoms: {2}, Telefon: {3}, Correu: {4} ", treballador.NIF, treballador.Nom, treballador.Cognoms, treballador.Telefon, treballador.Correu)
                );
            }

            Console.Read();
        }
    }
}
