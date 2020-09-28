using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async  Task<List<QtdEntradaSaidaHora>> QtdEntradaSaidaHoraDTO (Guid id)
        {
            var result = await _relatorioRepository.QtdEntradaSaidaHoraDTO(id);

            return result;
        }
    }
}
