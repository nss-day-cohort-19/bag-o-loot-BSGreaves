using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ToyRegister
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ToyRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public bool AddToy (int childid, string toy)
        {
            int _lastId = 0;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"insert into toy values (null, '{toy}', {childid})";
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
        public bool RevokeToy (int childid, int toyid)
        {
            return true;
        }
        public List<string> GetToyList (int childid) 
        {
            List<string> toyList = new List <string>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = $@"select t.name
                                    from toy t join child c
                                    on t.childid = c.childid
                                    where t.childid = {childid}";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        toyList.Add(dr[0].ToString());
                    }
                }
                _connection.Open();
            }
            return toyList;
        }
    }
}