using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using IPer;
using Model;

namespace Per
{

    public class PastaPersistence : IPastaPersistence
    {
        static string connectionString = @"Data Source=Byside.db";

        public void criarPasta(string nome, string localizacao)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                   $"INSERT INTO PASTA(nome, localizacao) VALUES('{nome}', '{localizacao}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Pasta> listarPastas()
        {
            List<Pasta> fim = new List<Pasta>();
           
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"SELECT * FROM Pasta ";

                List<Pasta> tableData = new();

                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                        new Pasta
                        {
                            Nome = reader.GetString(0),
                            Localizacao = reader.GetString(1)
                        }); ;
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                fim = tableData;

                connection.Close();

            }

            return fim;
        }
    }
}