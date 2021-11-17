using System;
using System.Collections.Generic;
using System.Text;
using ToDoList_WPF.Entitats;
using ToDoList_WPF.Persistence;
using System.Data.SQLite;

namespace ToDoList_WPF.Servei
{
    class TascaServei
    {
        public static IEnumerable<TascaDades> GetAll()
        {
            var result = new List<TascaDades>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM tasca";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new TascaDades
                            {
                                Codi = Convert.ToInt32(reader["Codi"].ToString()),
                                Titol = reader["Titol"].ToString(),
                                Descripcio = reader["Descripcio"].ToString(),
                                dCreacio = Convert.ToDateTime(reader["dCreacio"].ToString()),
                                dFinalitzacio = Convert.ToDateTime(reader["dFinalitzacio"].ToString()),
                                Prioritat = reader["Prioritat"].ToString(),
                                Representant = reader["Representant"].ToString(),
                                Estat = reader["Estat"].ToString(),
                            });
                        }
                    }
                }
                return result;
            }
        }
    }
}

