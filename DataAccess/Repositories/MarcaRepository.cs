using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private SqlConnection _connection;
        private IConfiguration _configuration;

        public MarcaRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = configuration.GetConnectionString("Geral");

            _configuration = configuration;
        }
        public IEnumerable<Marca> Get()
        {
            List<Marca> valueReturned;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT MarcaId, Nome FROM Marca ORDER BY MarcaId";

                _connection.Open();
                var result = command.ExecuteReader();

                valueReturned = new List<Marca>();
                while (result.Read())
                {
                    valueReturned.Add(new Marca
                    {
                        MarcaId = Convert.ToInt32(result[0]),
                        Nome = result[1].ToString()
                    });
                }
            }
            catch (Exception)
            {
                valueReturned = null;
            }
            finally
            {
                _connection.Close();
            }

            return valueReturned;
        }
        public IEnumerable<Patrimonio> GetPatrimonio(int id)
        {
            var repository = new PatrimonioRepository(_configuration);
            return repository.GetByMarcaId(id);
        }
        public Marca Get(int id)
        {
            Marca valueReturned = new Marca
            {
                MarcaId = -1
            };

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT MarcaId, Nome FROM Marca WHERE MarcaId=@Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    valueReturned = new Marca
                    {
                        MarcaId = Convert.ToInt32(result[0]),
                        Nome = result[1].ToString()
                    };
                }
            }
            catch (Exception)
            {
                valueReturned = null;
            }
            finally
            {
                _connection.Close();
            }

            return valueReturned;
        }
        public Marca Insert(Marca marca)
        {
            Marca valueReturned = null;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO Marca (Nome) VALUES (@Nome); SELECT @@IDENTITY AS Id";
                command.Parameters.AddWithValue("@Nome", marca.Nome);

                _connection.Open();
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    marca.MarcaId = Convert.ToInt32(result[0]);
                    valueReturned = marca;
                }
            }
            catch (Exception)
            {
                valueReturned = null;
            }
            finally
            {
                _connection.Close();
            }

            return valueReturned;
        }
        public int? Update(int id, Marca marca)
        {
            int? result;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText = "UPDATE Marca SET Nome=@Nome WHERE MarcaId=@Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nome", marca.Nome);

                _connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }
        public int? Delete(int id)
        {
            int? result;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM Marca WHERE MarcaId=@Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }
    }
}
