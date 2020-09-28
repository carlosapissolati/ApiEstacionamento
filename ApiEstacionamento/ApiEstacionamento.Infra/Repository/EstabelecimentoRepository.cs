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
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly EstacionamentoContext _estacionamentoContext;

        public EstabelecimentoRepository(EstacionamentoContext estacionamentoContext)
        {
            _estacionamentoContext = estacionamentoContext;
        }

        public async Task<Estabelecimento> BuscarPorIdAsync(Guid id)
        {
           var estabelecimento = await _estacionamentoContext.Estabelecimentos.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return estabelecimento;
        }

        public async Task<Estabelecimento> BuscarPorCnpjAsync(string cnpj)
        {
            var estabelecimento = await _estacionamentoContext.Estabelecimentos.AsNoTracking().FirstOrDefaultAsync(u => u.CNPJ == cnpj);
            return estabelecimento;
        }

        public async Task<Estabelecimento> AdicionarAsync(Estabelecimento  estabelecimento)
        {
            _estacionamentoContext.Estabelecimentos.Add(estabelecimento);
            await _estacionamentoContext.SaveChangesAsync();
            return estabelecimento;
        }

        public async Task<Estabelecimento> AlterarAsync(Estabelecimento estabelecimento)
        {
            _estacionamentoContext.Estabelecimentos.Update(estabelecimento);
            await _estacionamentoContext.SaveChangesAsync();
            return estabelecimento;
        }

        public async Task<Estabelecimento> DeletarAsync(Estabelecimento estabelecimento)
        {
            _estacionamentoContext.Estabelecimentos.Remove(estabelecimento);
            await _estacionamentoContext.SaveChangesAsync();
            return estabelecimento;
        }
    }
}
