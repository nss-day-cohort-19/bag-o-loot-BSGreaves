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
        public bool AddToy (int childid, int toyid)
        {
            return true;
        }
        public bool RevokeToy (int childid, int toyid)
        {
            return true;
        }
        public List<string> GetToyList () 
        {
            return new List<string>();
            //Eventually, will return void and store values in a local private List
        }
    }
}