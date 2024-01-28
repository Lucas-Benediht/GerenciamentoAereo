using SistemaGerenciamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerenciamento.Interface
{
    // Interface:
    // Contrato que define um conjunto de métodos que uma classe pode implementar.
    public interface IAeroportoService
    {
        Aeroporto ObterCodigoAeroporto(string codigoAeroporto);
        Aeroporto ObterNomeAeroporto(string nomeAeroporto);
    }
}
