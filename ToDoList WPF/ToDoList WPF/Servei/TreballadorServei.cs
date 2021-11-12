using System;
using System.Collections.Generic;
using System.Text;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Persistence;
using System.Data.SQLite;

namespace ToDoList_WPF.Servei
{
    class TreballadorServei
    {
        public static IEnumerable<TreballadorDades> GetAll()
        {
            var result = new List<TreballadorDades>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM treballador";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new TreballadorDades
                            {
                                NIF = reader["NIF"].ToString(),
                                Nom = reader["Nom"].ToString(),
                                Cognoms = reader["Cognoms"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Correu = reader["Correu"].ToString(),
                            });
                        }
                    }
                }
                return result;
            }
        }
    }
}
