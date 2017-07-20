using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BagOLoot
{
    public class DatabaseInterface
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public DatabaseInterface()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public void CheckDB ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"select childID from child";
                try
                {
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table child (
                            `childID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) NOT NULL, 
                            `delivered` integer NOT NULL DEFAULT 0
                        )";
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                _connection.Open();
                dbcmd.CommandText = $"select toyID from toy";
                try
                {
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                    }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table toy (
                            `toyID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) NOT NULL, 
                            `childID` integer DEFAULT NULL,
                            FOREIGN KEY(`childid`) REFERENCES `child`(`childid`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }
        public void DropAndSeedDB ()
        {
            using (_connection)
            {
                List <string> ChildSeed = new List <string>()
                {
                    "Billy",
                    "Tommy",
                    "Sue",
                    "Sarah"
                };
                List <string> ToySeed = new List <string>()
                {
                    "Xbox",
                    "Trampoline",
                    "Motorcycle",
                    "Ball-in-a-cup"
                };
                _connection.Open();
                executeSQLNonQuery("DROP TABLE IF EXISTS child");
                executeSQLNonQuery("DROP TABLE IF EXISTS toy");
                executeSQLNonQuery($@"create table child (
                            `childID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) NOT NULL, 
                            `delivered` integer NOT NULL DEFAULT 0)");
                executeSQLNonQuery($@"create table toy (
                            `toyID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) NOT NULL, 
                            `childID` integer DEFAULT NULL,
                            FOREIGN KEY(`childid`) REFERENCES `child`(`childid`))");
                foreach (string child in ChildSeed)
                {
                    string SQLString = $"INSERT INTO child VALUES (null, '{child}', 0)";
                    executeSQLNonQuery(SQLString);
                }
                foreach (string toy in ToySeed)
                {
                    executeSQLNonQuery($"INSERT INTO toy VALUES (null, '{toy}', null)");
                }
                _connection.Close ();
            }
        }
        public void executeSQLNonQuery(string sql)
        {
            SqliteCommand dbcmd = _connection.CreateCommand ();
            dbcmd.CommandText = $"{sql}";
            dbcmd.ExecuteNonQuery ();
            dbcmd.Dispose ();
        }
    }
}

// using (SqliteDataReader dr = dbcmd.ExecuteReader)
// {
//     while (dr.Read())
//     {
//         _children.Add(dr[1].ToString());
//     }
// }