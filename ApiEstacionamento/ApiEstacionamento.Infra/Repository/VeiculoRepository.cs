using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infra.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly EstacionamentoContext _estacionamentoContext;

        public VeiculoRepository(EstacionamentoContext estacionamentoContext)
        {
            _estacionamentoContext = estacionamentoContext;
        }


        public async Task<Veiculo> BuscarPorIdAsync(Guid id)
        {
            var veiculo = await _estacionamentoContext.Veiculos.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return veiculo;
        }

        public async Task<Veiculo> BuscarPelaPlacaAsync(string placa)
        {
            var veiculo = await _estacionamentoContext.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Placa == placa);
            return veiculo;
        }

        public async Task<Veiculo> AdicionarAsync(Veiculo veiculo)
        {
            _estacionamentoContext.Veiculos.Add(veiculo);
            await _estacionamentoContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<Veiculo> AlterarAsync(Veiculo veiculo)
        {
            _estacionamentoContext.Veiculos.Update(veiculo);
            await _estacionamentoContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<Veiculo> DeletarAsync(Veiculo veiculo)
        {
            _estacionamentoContext.Veiculos.Remove(veiculo);
            await _estacionamentoContext.SaveChangesAsync();
            return veiculo;
        }

    }
}
