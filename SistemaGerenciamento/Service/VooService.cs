using SistemaGerenciamento.Data;
using SistemaGerenciamento.Interface;
using SistemaGerenciamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemaGerenciamento.Service
{
    public class VooService : IVooService
    {
        public Voo ObtemPorNumeroVoo(int numeroVoo)
        {
            using (var context = new DatabaseContext())
            using (var command = context.CreateCommand())
            {
                command.CommandText = "SELECT numero_voo, partida, destino, hora_partida, hora_chegada FROM Voo WHERE numero_voo = @NumeroVoo";
                command.Parameters.AddWithValue("@NumeroVoo", numeroVoo);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new Exception($"O número do Voo: {numeroVoo} não foi encontrado! Por gentileza, verifique novamente.");
                    }
                    return new Voo
                    {
                        NumeroVoo = reader.GetInt32(0),
                        Partida = reader.GetString(1),
                        Destino = reader.GetString(2),
                        HoraPartida = reader.GetDateTime(3),
                        HoraChegada = reader.GetDateTime(4)
                    };
                }
            }

        }
    }
}
