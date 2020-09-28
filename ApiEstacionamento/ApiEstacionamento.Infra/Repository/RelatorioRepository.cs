using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infra.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly EstacionamentoContext _estacionamentoContext;

        public RelatorioRepository(EstacionamentoContext estacionamentoContext)
        {
            _estacionamentoContext = estacionamentoContext;
        }


        public async Task<List<QtdEntradaSaidaHora>> QtdEntradaSaidaHoraDTO(Guid estabelecimentoId)
        {
 

            long qtdEntrada = 0;
            long qtdSaida= 0;
            List<QtdEntradaSaidaHora> qtdEntradaSaidaHoraDTO = new List<QtdEntradaSaidaHora>();

            var controle = await _estacionamentoContext.ControleVeiculo.Where(c => c.EstabelecimentoId == estabelecimentoId ).ToListAsync();
            var controleVeiculos = controle.GroupBy(c => c.DataHoraEntrada.Hour).ToList();

            foreach (var itemControle in controleVeiculos)
            {
                foreach (var item in itemControle)
                {
                    if (item.DataHoraEntrada != null)
                        qtdEntrada += 1;

                    if (item.DataHoraSaida != null)
                        qtdSaida += 1;
                }
                qtdEntradaSaidaHoraDTO.Add(new QtdEntradaSaidaHora { Hora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, itemControle.Key, 0, 0) , EstabelecimentoId = estabelecimentoId.ToString(), QtdEntrada = qtdEntrada, QtdSaida= qtdSaida });
            }


            return qtdEntradaSaidaHoraDTO;
        }
    }
}
