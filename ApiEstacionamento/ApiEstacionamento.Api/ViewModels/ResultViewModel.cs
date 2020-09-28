using ApiEstacionamento.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(object data)
        {
            Success = true;
            Data = data;
        }

        public ResultViewModel(List<Notificacao> notificacaos)
        {
            Success = false;
            Data = null;
            ErroList = notificacaos;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public List<Notificacao> ErroList { get; set; }
    }
}
