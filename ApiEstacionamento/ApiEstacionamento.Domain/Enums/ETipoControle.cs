using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiEstacionamento.Domain.Enums
{
    public enum ETipoControle
    {
        [Description("Entrada")]
        Entrada = 1,

        [Description("Saida")]
        Saida = 2
    }
}
