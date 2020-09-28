using ApiEstacionamento.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ApiEstacionamento.Api.Extensions
{
    public static class ModelError
    {

        public static List<Notificacao> GetErrorModelState(ModelStateDictionary modelState, Notificador notificador)
        {
                
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                notificador.Add("",errorMsg);
            }

            return notificador.ObterNotificacoes();
        }

        public static object GetErrorValidacao(Notificador notificador)
        {
            return new { Error = notificador.ObterNotificacoes().Select(x => x.Mensagem) };
        }

    }
}