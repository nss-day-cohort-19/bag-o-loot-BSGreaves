using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ChildRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AddChild (string child) 
        {
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"insert into child values (null, '{child}', 0)";
                dbcmd.ExecuteNonQuery ();
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _lastId != 0;
        }

        public List <(string, int)> GetChildList ()
        {
            List <(string, int)> childList = new List <(string, int)>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = $"select c.name, c.childID from child c";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        childList.Add((dr[0].ToString(), dr.GetInt32(1)));
                    }
                }
                _connection.Open();
            }
            return childList;
        }

        public int GetChild (string name)
        {
            
            //Should take a name, search the DB for the string, and return the correct ID
            return 4;
        }
    }
}