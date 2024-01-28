using SistemaGerenciamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerenciamento.Interface
{
    public interface IVooService
    {
        Voo ObtemPorNumeroVoo(int numeroVoo);
    }
}

