using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class DeliveryManager
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;
        public DeliveryManager ()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public bool ConfirmDelivery (int childid)
        {
            return true;
        }
        public List<string> ListConfirmedDeliveries ()
        {
            return new List <string>();
        }
    }
}