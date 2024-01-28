using SistemaGerenciamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerenciamento.Interface
{
    public interface IPassageiroService
    {
        Passageiro CriarNovoPassageiro(string nomeCompleto, int idade);
        Passageiro ObterPassageiroPorNome(string nomePassageiro);
        Passageiro ObterPassageiroPorId(string idPassageiro);

    }
}
