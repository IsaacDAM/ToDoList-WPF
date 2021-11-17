using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace ToDoList_WPF.Persistence
{
    class DbContext
    {
        private const String DBName = "demo_sqlite.sqlite";
        private const String SQLScript = @"..\..\..\Util\demo_sqlite.sql";
        private static bool IsDbRecentlyCreated = false;

        public static void Up()
        {
            // Crea la base de datos solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            using (var ctx = GetInstance())
            {
                // Crea la base de datos solo la primera vez
                if (IsDbRecentlyCreated)
                {
                    using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
                    {
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    for (var i = 1; i <= 100; i++)
                    {
                        var query1 = "INSERT INTO tasca (titol, descripcio, dCreacio, dFinalitz, prioritat, representant, estat) VALUES (?, ?, ?, ?, ?, ?, ?)";
                        var query2 = "INSERT INTO treballador (NIF, nom, cognoms, telefon, correu) VALUES (?, ?, ?, ?, ?)";

                        using (var command = new SQLiteCommand(query1, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("titol", "Titol " + i));
                            command.Parameters.Add(new SQLiteParameter("descripcio", "Descripcio " + i));
                            command.Parameters.Add(new SQLiteParameter("dCreacio", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            command.Parameters.Add(new SQLiteParameter("dFinalitz", DateTime.Today.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")));
                            command.Parameters.Add(new SQLiteParameter("prioritat", "Prioritat "  + i));
                            command.Parameters.Add(new SQLiteParameter("representant", "Representant " + i));
                            command.Parameters.Add(new SQLiteParameter("estat", "Estat " + i));

                            command.ExecuteNonQuery();
                        }
                        using (var command = new SQLiteCommand(query2, ctx))
                        {
                            command.Parameters.Add(new SQLiteParameter("nif", "NIF " + i));
                            command.Parameters.Add(new SQLiteParameter("nom", "Nom " + i));
                            command.Parameters.Add(new SQLiteParameter("cognoms", "Cognoms " + i));
                            command.Parameters.Add(new SQLiteParameter("telefon", "Telefon " + i));
                            command.Parameters.Add(new SQLiteParameter("correu", "Correu " + i));

                            command.ExecuteNonQuery();
                        }

                    }
                }
            }
        }
        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                String.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }
    }
}

