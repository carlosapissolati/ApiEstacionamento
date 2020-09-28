using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEstacionamento.Domain.Models
{
    public class QtdEntradaSaidaHora
    {
        public string EstabelecimentoId { get; set; }
        public DateTime Hora { get; set; }

        public long QtdEntrada { get; set; }

        public long QtdSaida { get; set; }
    }
}
