using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Service
{
    public interface IVeiculoService
    {
        Task<Veiculo> BuscarVeiculoIdAsync(Guid id);
        Task<Veiculo> AdicionarVeiculoAsync(Veiculo veiculoDTO);
        Task<Veiculo> AlterarVeiculoAsync(Veiculo veiculoDTO);
        Task<Veiculo> DeletarVeiculo(Guid id);
    }
}
