﻿using System;
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
            List<TascaDades> result = new List<TascaDades>();

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
                                dFinalitzacio = Convert.ToDateTime(reader["dFinalitz"].ToString()),
                                Prioritat = reader["Prioritat"].ToString(),
                                Representant = reader["Representant"].ToString(),
                                Estat = reader["Estat"].ToString()
                            });
                        }
                    }
                }
                return result;
            }
        }

        public int Add(TascaDades tasca)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO tasca (titol, descripcio, dCreacio, dFinalitz, prioritat, representant, estat) VALUES (?, ?, ?, ?, ?, ?, ?)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("titol", tasca.Titol));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("dCreacio", tasca.dCreacio));
                    command.Parameters.Add(new SQLiteParameter("dFinalitz", tasca.dFinalitzacio));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));
                    command.Parameters.Add(new SQLiteParameter("representant", tasca.Representant));
                    command.Parameters.Add(new SQLiteParameter("estat", tasca.Estat));

                    rows_afected = command.ExecuteNonQuery();
                }   
            }
            return rows_afected;
        }

        public int Update(TascaDades tasca)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE tasca SET titol = ?, descripcio = ?, dCreacio = ?, dFinalitz = ?, prioritat = ?, representant = ?, estat = ? WHERE codi = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("titol", tasca.Titol));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("dCreacio", tasca.dCreacio));
                    command.Parameters.Add(new SQLiteParameter("dFinalitz", tasca.dFinalitzacio));
                    command.Parameters.Add(new SQLiteParameter("prioritat", tasca.Prioritat));
                    command.Parameters.Add(new SQLiteParameter("representant", tasca.Representant));
                    command.Parameters.Add(new SQLiteParameter("estat", tasca.Estat));

                    rows_afected = command.ExecuteNonQuery();
                }
            }
            return rows_afected;
        }


    }
}

