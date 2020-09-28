using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEstacionamento.Domain.Notificacoes
{
    public class Notificacao
    {
        public Notificacao( string propriedade, string mensagem)
        {

            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; private set; }
        public string Mensagem { get; private set; }
    }
}
