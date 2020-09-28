using ApiEstacionamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.ViewModels
{
    public class ControleViewModel
    {
        public Guid EstabelecimentoId { get; set; }
        public Guid VeiculoId { get; set; }

        public ETipoControle TipoControle { get; set; }

        public ETipo Tipo { get; set; }
    }
}
