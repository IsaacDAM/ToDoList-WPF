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

