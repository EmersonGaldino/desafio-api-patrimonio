using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class PatrimonioRepository
    {
        private SqlConnection _connection;
        private IConfiguration _configuration;

        public PatrimonioRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = configuration.GetConnectionString("Geral");

            _configuration = configuration;
        }
        public IEnumerable<Patrimonio> Get()
        {
            List<Patrimonio> valueReturned;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT NroTombo, MarcaId, Nome, Descricao FROM Patrimonio ORDER BY NroTombo";

                _connection.Open();
                var result = command.ExecuteReader();

                valueReturned = new List<Patrimonio>();
                while (result.Read())
                {
                    valueReturned.Add(new Patrimonio
                    {
                        NroTombo = Convert.ToInt32(result[0]),
                        MarcaId = Convert.ToInt32(result[1]),
                        Nome = result[2].ToString(),
                        Descricao = result[3].ToString()
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
        public Patrimonio Get(int id)
        {
            Patrimonio valueReturned = new Patrimonio
            {
                NroTombo = -1
            };

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT NroTombo, MarcaId, Nome, Descricao FROM Patrimonio WHERE NroTombo=@Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    valueReturned = new Patrimonio
                    {
                        NroTombo = Convert.ToInt32(result[0]),
                        MarcaId = Convert.ToInt32(result[1]),
                        Nome = result[2].ToString(),
                        Descricao = result[3].ToString()
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
        public IEnumerable<Patrimonio> GetByMarcaId(int id)
        {
            List<Patrimonio> valueReturned;

            try
            {
                var command = _connection.CreateCommand();
                command.CommandText =
                    "SELECT NroTombo, MarcaId, Nome, Descricao FROM Patrimonio WHERE MarcaId=@MarcaId ORDER BY NroTombo";
                command.Parameters.AddWithValue("@MarcaId", id);

                _connection.Open();
                var result = command.ExecuteReader();

                valueReturned = new List<Patrimonio>();
                while (result.Read())
                {
                    valueReturned.Add(new Patrimonio
                    {
                        NroTombo = Convert.ToInt32(result[0]),
                        MarcaId = Convert.ToInt32(result[1]),
                        Nome = result[2].ToString(),
                        Descricao = result[3].ToString()
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
        public Patrimonio Insert(Patrimonio patrimonio)
        {
            Patrimonio valueReturned = null;

            try
            {
                var commandText = string.Format("INSERT INTO Patrimonio(MarcaId, Nome{0}) VALUES (@MarcaId, @Nome{1}); SELECT @@IDENTITY AS Id",
                    (patrimonio.Descricao == null || patrimonio.Descricao == string.Empty) ? string.Empty : ", Descricao",
                    (patrimonio.Descricao == null || patrimonio.Descricao == string.Empty) ? string.Empty : ", @Descricao"
                );

                var command = _connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddWithValue("@MarcaId", patrimonio.MarcaId);
                command.Parameters.AddWithValue("@Nome", patrimonio.Nome);

                if (patrimonio.Descricao != null)
                    command.Parameters.AddWithValue("@Descricao", patrimonio.Descricao);

                _connection.Open();
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    patrimonio.NroTombo = Convert.ToInt32(result[0]);
                    valueReturned = patrimonio;
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
        public int? Update(int id, Patrimonio patrimonio)
        {
            int? result;

            try
            {
                var commandText = "UPDATE Patrimonio SET ";
                var modifications = 0;
                if(patrimonio.Nome != null && patrimonio.Nome != string.Empty)
                {
                    commandText = string.Format("{0}Nome=@Nome", commandText);
                    modifications++;
                }
                if (patrimonio.MarcaId > 0)
                {
                    commandText = string.Format("{0}{1}MarcaId=@MarcaId", commandText, modifications > 0 ? "," : string.Empty);
                    modifications++;
                }
                if (patrimonio.Descricao != null && patrimonio.Descricao != string.Empty)
                {
                    commandText = string.Format("{0}{1}Descricao=@Descricao", commandText, modifications > 0 ? "," : string.Empty);
                    modifications++;
                }
                commandText = string.Format("{0}{1}", commandText, " WHERE NroTombo=@Id");

                var command = _connection.CreateCommand();
                command.CommandText = commandText;
                if (patrimonio.Nome != null && patrimonio.Nome != string.Empty)
                    command.Parameters.AddWithValue("@Nome", patrimonio.Nome);
                if (patrimonio.MarcaId > 0)
                    command.Parameters.AddWithValue("@MarcaId", patrimonio.MarcaId);
                if (patrimonio.Descricao != null && patrimonio.Descricao != string.Empty)
                    command.Parameters.AddWithValue("@Descricao", patrimonio.Descricao);
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
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
                command.CommandText = "DELETE FROM Patrimonio WHERE NroTombo=@Id";
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
