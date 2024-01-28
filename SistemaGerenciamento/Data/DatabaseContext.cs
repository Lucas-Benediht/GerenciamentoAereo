using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaGerenciamento.Data
{
    public class DatabaseContext : IDisposable
    {
        private readonly string connectionString;
        private readonly SqliteConnection connection;

        public DatabaseContext()
        {
            connectionString = @"Data Source=C:\Users\Benee\Desktop\GestaoAero\GestaoAeroportos.db";
            connection = new SqliteConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexão ao banco de dados aberta com sucesso.");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir a conexão com o banco de dados: {ex.Message}");
            }
        }

        public SqliteCommand CreateCommand()
        {
            return connection.CreateCommand();
        }

        public void Dispose()
        {
            connection.Dispose();
            connection.Close();
        }
    }
}
