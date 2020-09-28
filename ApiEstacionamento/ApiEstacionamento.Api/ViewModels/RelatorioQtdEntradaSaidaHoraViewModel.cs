using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.ViewModels
{
    public class RelatorioQtdEntradaSaidaHoraViewModel
    {
        public string EstabelecimentoId { get; set; }
        public DateTime Hora { get; set; }

        public long QtdEntrada { get; set; }

        public long QtdSaida { get; set; }
    }
}
