using SistemaGerenciamento.Models;
using Microsoft.Data.Sqlite;
using System;
using SistemaGerenciamento.Data;
using SQLitePCL;

namespace SistemaGerenciamento.Interface
{
    public class AeroportoService : IAeroportoService
    {
        public Aeroporto ObterCodigoAeroporto(string codigo)
        {
            Batteries.Init();

            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "SELECT Codigo, Nome FROM Aeroportos WHERE Codigo = @Codigo";
                command.Parameters.AddWithValue("@Codigo", codigo);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new Exception($"Aeroporto com código: {codigo} não encontrado");
                    }

                    return new Aeroporto
                    {
                        Codigo = reader.GetString(0),
                        Nome = reader.GetString(1)
                    };
                }
            }
        }
        public Aeroporto ObterNomeAeroporto(string nome)
        {
            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "SELECT Codigo, Nome FROM Aeroportos WHERE Nome = @Nome";
                command.Parameters.AddWithValue("@Nome", nome);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new Exception($"Aeroporto com nome: {nome} não encontrado");
                    }

                    return new Aeroporto
                    {
                        Codigo = reader.GetString(0),
                        Nome = reader.GetString(1)
                    };
                }
            }
        }
    }
}
