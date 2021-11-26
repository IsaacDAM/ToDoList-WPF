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

        public int Add(TreballadorDades treballador)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            { 
                string query = "SELECT count(*) FROM treballador WHERE NIF = ?";
                string query2 = "INSERT INTO treballador (NIF, nom, cognoms, telefon, correu) VALUES (?, ?, ?, ?, ?)";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nif", treballador.NIF));
                    int dup = Convert.ToInt32(command.ExecuteScalar());
                    if (dup == 0)
                    {
                        using (var command2 = new SQLiteCommand(query2, ctx))
                        {
                            command2.Parameters.Add(new SQLiteParameter("nif", treballador.NIF));
                            command2.Parameters.Add(new SQLiteParameter("nom", treballador.Nom));
                            command2.Parameters.Add(new SQLiteParameter("cognoms", treballador.Cognoms));
                            command2.Parameters.Add(new SQLiteParameter("telefon", treballador.Telefon));
                            command2.Parameters.Add(new SQLiteParameter("correu", treballador.Correu));

                            rows_afected = command2.ExecuteNonQuery();
                        }
                    }
                }
            }
            return rows_afected;
        }

        public int Update(TreballadorDades treballador, String NIF)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE treballador SET NIF = ?, nom = ?, cognoms = ?, telefon = ?, correu = ? WHERE NIF = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("nif", treballador.NIF));
                    command.Parameters.Add(new SQLiteParameter("nom", treballador.Nom));
                    command.Parameters.Add(new SQLiteParameter("cognoms", treballador.Cognoms));
                    command.Parameters.Add(new SQLiteParameter("telefon", treballador.Telefon));
                    command.Parameters.Add(new SQLiteParameter("correu", treballador.Correu));
                    command.Parameters.Add(new SQLiteParameter("onif", NIF));
                    try
                    {
                        rows_afected = command.ExecuteNonQuery();
                    }
                    catch (SQLiteException) { }
                }
            }
            return rows_afected;
        }

        public int Delete(TreballadorDades treballador)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM treballador WHERE NIF = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("NIF", treballador.NIF));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }

    }
}
