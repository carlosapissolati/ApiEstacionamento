using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> BuscarPorIdAsync(Guid id);
        Task<Veiculo> BuscarPelaPlacaAsync(string placa);
        Task<Veiculo> AdicionarAsync(Veiculo veiculo);
        Task<Veiculo> AlterarAsync(Veiculo veiculo);
        Task<Veiculo> DeletarAsync(Veiculo veiculo);

    }
}
