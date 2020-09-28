using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiEstacionamento.Domain.Enums
{
    public enum ETipo
    {
        [Description("Automovel")]
        Automovel = 1,

        [Description("Moto")]
        Moto = 2
    }
}
