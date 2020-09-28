using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Services
{
   public  class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository ;
        private readonly IEstabelecimentoRepository  _estabelecimentoRepository;
        private readonly Notificador _notificador;

        public VeiculoService(IVeiculoRepository veiculoRepository, Notificador notificador , IEstabelecimentoRepository estabelecimentoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _notificador = notificador;
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public async Task<Veiculo> BuscarVeiculoIdAsync(Guid id)
        {

            Veiculo retornoVeiculo = await _veiculoRepository.BuscarPorIdAsync(id);

            if (retornoVeiculo == null)
            {
                _notificador.Add("Veiculo", "Veiculo não encontrado com esse Id");
                return null;
            }
            return retornoVeiculo;

        }

        public async Task<Veiculo> AdicionarVeiculoAsync(Veiculo veiculoDTO)
        {
            veiculoDTO.Id = Guid.NewGuid();
            veiculoDTO.DataCadastro = DateTime.Now;

            Veiculo retornoVeiculo = await _veiculoRepository.BuscarPelaPlacaAsync(veiculoDTO.Placa);
            if (retornoVeiculo != null)
            {
                _notificador.Add("Veiculo", "Já existe o Veiculo com essa Placa");
                return null;
            }

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorIdAsync(veiculoDTO.EstabelecimentoId);

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Veiculo", "Não existe Veiculo com esse ID");
                return null;
            }

            var veiculo = await _veiculoRepository.AdicionarAsync(veiculoDTO);
            return veiculo;
        }


        public async Task<Veiculo> AlterarVeiculoAsync(Veiculo veiculoDTO)
        {

            Veiculo retornoVeiculo = await _veiculoRepository.BuscarPelaPlacaAsync(veiculoDTO.Placa);

            if (retornoVeiculo == null)
            {
                _notificador.Add("Veiculo", "Não existe Veiculo com essa Placa");
                return null;
            }

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorIdAsync(veiculoDTO.EstabelecimentoId);

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Veiculo", "Não existe Veiculo com esse ID");
                return null;
            }

            Veiculo veiculoAlterado = new Veiculo();
            veiculoAlterado.Id = retornoVeiculo.Id;
            veiculoAlterado.Placa = retornoVeiculo.Placa;
            veiculoAlterado.Modelo = veiculoDTO.Modelo;
            veiculoAlterado.Marca = veiculoDTO.Marca;
            veiculoAlterado.Cor = veiculoDTO.Cor;
            veiculoAlterado.Tipo = veiculoDTO.Tipo;
            veiculoAlterado.EstabelecimentoId = veiculoDTO.EstabelecimentoId;
            veiculoAlterado.DataCadastro = veiculoDTO.DataCadastro;

            var veiculo = await _veiculoRepository.AlterarAsync(veiculoAlterado);
            return veiculo;
        }


        public async Task<Veiculo> DeletarVeiculo(Guid id)
        {

            Veiculo retornoVeiculo = await _veiculoRepository.BuscarPorIdAsync(id);

            if (retornoVeiculo == null)
            {
                _notificador.Add("Veiculo", "Veiculo não encontrado com esse Id");
                return null;
            }

            await _veiculoRepository.DeletarAsync(retornoVeiculo);

            return retornoVeiculo;

        }
    }
}
