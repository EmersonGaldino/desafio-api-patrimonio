using System;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class MarcasRepository
    {
        private string _connectionString = "Data Source=localhost;User ID=sa;Password=sa;Initial Catalog=desafio-partner-group;";
        private SqlConnection _connection;

        public MarcasRepository()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = _connectionString;

            try
            {
                _connection.Open();
            }
            catch(Exception e)
            {

            }
        }
    }
}
