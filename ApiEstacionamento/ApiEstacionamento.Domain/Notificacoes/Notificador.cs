using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiEstacionamento.Domain.Notificacoes
{
    public class Notificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Add(string propriedade, string mensagem)
        {
            Notificacao notificacao = new Notificacao(propriedade, mensagem);

            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
