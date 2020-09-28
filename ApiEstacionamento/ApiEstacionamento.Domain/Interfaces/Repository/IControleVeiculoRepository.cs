using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Repository
{
    public interface IControleVeiculoRepository
    {
        Task<ControleVeiculo> AdicionarAsync(ControleVeiculo controleVeiculo);
        Task<int> QuantidadeAutmovelDentroEstabelecimento(ControleVeiculo controleVeiculo);
        Task<int> QuantidadeMotoDentroEstabelecimento(ControleVeiculo controleVeiculo);
        Task<ControleVeiculo> VerificarVeiculoEstaDentroEstabelecimento(ControleVeiculo controleVeiculo);
        Task<ControleVeiculo> AlterarAsync(ControleVeiculo controleVeiculo);
    }
}
