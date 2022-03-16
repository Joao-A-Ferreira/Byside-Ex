
using Microsoft.Data.Sqlite;

namespace Per{
public class FicheiroPersistence : IFicheiroPersistence{
    static string connectionString = @"Data Source=Byside.db";

    public void cirarFicheiro(string nome, string localizacao){

     using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                   $"INSERT INTO FICHEIRO(nome, localizacao) VALUES('{nome}', '{localizacao}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
    }
}
}