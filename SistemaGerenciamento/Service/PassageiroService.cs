using SistemaGerenciamento.Data;
using SistemaGerenciamento.Interface;
using SistemaGerenciamento.Models;
using System;
using System.Data;

namespace SistemaGerenciamento.Service
{
    public class PassageiroService : IPassageiroService
    {
        public Passageiro ObterPassageiroPorNome(string nomePassageiro)
        {
            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "SELECT id, nome_completo FROM Passageiros WHERE nome_completo = @Nome";
                command.Parameters.AddWithValue("@Nome", nomePassageiro);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new Exception($"Passageiro com o nome: {nomePassageiro} não encontrado");
                    }

                    return new Passageiro
                    {
                        IdPassageiro = reader.GetString(0),
                        NomeCompleto = reader.GetString(1)
                    };
                }
            }
        }

        public Passageiro ObterPassageiroPorId(string idPassageiro)
        {
            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "SELECT id, nome_completo FROM Passageiros WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", idPassageiro);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new Exception($"Passageiro com o ID: {idPassageiro} não encontrado");
                    }

                    return new Passageiro
                    {
                        IdPassageiro = reader.GetString(0),
                        NomeCompleto = reader.GetString(1)
                    };
                }
            }
        }

        public Passageiro CriarNovoPassageiro(string nomeCompleto, int idade)
        {
            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "INSERT INTO Passageiros (nome_completo, idade) VALUES (@NomeCompleto, @Idade)";
                command.Parameters.AddWithValue("@NomeCompleto", nomeCompleto);
                command.Parameters.AddWithValue("@Idade", idade);

                command.ExecuteNonQuery();
                command.CommandText = "SELECT last_insert_rowid()";
                string id = command.ExecuteScalar().ToString();

                return new Passageiro
                {
                    IdPassageiro = id,
                    NomeCompleto = nomeCompleto,
                    Idade = idade
                };
            }
        }
    }
}
