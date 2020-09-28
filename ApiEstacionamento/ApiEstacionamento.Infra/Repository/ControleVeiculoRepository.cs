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
   public  class ControleVeiculoRepository : IControleVeiculoRepository
    {
        private readonly EstacionamentoContext _estacionamentoContext;

        public ControleVeiculoRepository(EstacionamentoContext estacionamentoContext)
        {
            _estacionamentoContext = estacionamentoContext;
        }

        public async Task<ControleVeiculo> AdicionarAsync(ControleVeiculo  controleVeiculo)
        {
            _estacionamentoContext.ControleVeiculo.Add(controleVeiculo);
            await _estacionamentoContext.SaveChangesAsync();
            return controleVeiculo;
        }

        public async Task<ControleVeiculo> AlterarAsync(ControleVeiculo controleVeiculo)
        {
            _estacionamentoContext.ControleVeiculo.Update(controleVeiculo);
            await _estacionamentoContext.SaveChangesAsync();
            return controleVeiculo;
        }

        public async Task<ControleVeiculo> VerificarVeiculoEstaDentroEstabelecimento(ControleVeiculo controleVeiculo)
        {
            var controle = await _estacionamentoContext.ControleVeiculo.Include(e => e.estabelecimento).Include(v => v.Veiculo).Where(c => c.EstabelecimentoId == controleVeiculo.EstabelecimentoId && c.VeiculoId == controleVeiculo.VeiculoId && c.DataHoraSaida == null).FirstOrDefaultAsync();

            return controle;
        }


        public async Task<int> QuantidadeAutmovelDentroEstabelecimento(ControleVeiculo controleVeiculo)
        {
            int qtd = await _estacionamentoContext.ControleVeiculo.Where(c => c.EstabelecimentoId == controleVeiculo.EstabelecimentoId && c.TipoControle == 1 && c.Tipo ==1).CountAsync();
 
            return qtd;
        }

        public async Task<int> QuantidadeMotoDentroEstabelecimento(ControleVeiculo controleVeiculo)
        {
            int qtd = await _estacionamentoContext.ControleVeiculo.Where(c => c.EstabelecimentoId == controleVeiculo.EstabelecimentoId && c.TipoControle == 1 && c.Tipo == 2).CountAsync();

            return qtd;
        }

    }
}
