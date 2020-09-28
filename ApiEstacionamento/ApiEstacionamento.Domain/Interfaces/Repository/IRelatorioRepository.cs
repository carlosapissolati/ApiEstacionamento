using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Repository
{
    public interface IRelatorioRepository
    {
        Task<List<QtdEntradaSaidaHora>> QtdEntradaSaidaHoraDTO(Guid estabelecimentoId);
    }
}
