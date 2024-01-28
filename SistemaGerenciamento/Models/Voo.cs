using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerenciamento.Models
{
    public class Voo
    {
        public int NumeroVoo { get; set; }
        public string Partida { get; set; }
        public string Destino { get; set; }
        public DateTime HoraPartida { get; set; }
        public DateTime HoraChegada { get; set; }
    }
}
