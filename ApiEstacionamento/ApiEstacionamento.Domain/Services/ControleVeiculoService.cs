using ApiEstacionamento.Domain.Enums;
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
    public class ControleVeiculoService : IControleVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        private readonly IControleVeiculoRepository _controleVeiculoRepository;
        private readonly Notificador _notificador;

        public ControleVeiculoService(IVeiculoRepository veiculoRepository, IEstabelecimentoRepository estabelecimentoRepository, Notificador notificador, IControleVeiculoRepository controleVeiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _estabelecimentoRepository = estabelecimentoRepository;
            _notificador = notificador;
            _controleVeiculoRepository = controleVeiculoRepository;
        }


        public async Task<bool> ControleVeiculoAsync(ControleVeiculo controleVeiculo)
        {
            Veiculo retornoVeiculo = await _veiculoRepository.BuscarPorIdAsync(controleVeiculo.VeiculoId);
            if (retornoVeiculo == null)
            {
                _notificador.Add("Veiculo", "Não existe o Veiculo com esse ID");
                return false;
            }

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorIdAsync(controleVeiculo.EstabelecimentoId);

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Veiculo", "Não existe estabelecimento com esse ID");
                return false;
            }


            if (controleVeiculo.TipoControle == (int)ETipoControle.Entrada)
            {
                return await EntradaVeiculoAsync(controleVeiculo, retornoEstabelecimento);
            }
            else
            {
               return await SaidaVeiculoAsync(controleVeiculo, retornoEstabelecimento);
            }
        }


        public async Task<bool> EntradaVeiculoAsync(ControleVeiculo controleVeiculo, Estabelecimento estabelecimento)
        {
            if (controleVeiculo.Tipo == (int)ETipo.Automovel)
            {
                int qtd = await _controleVeiculoRepository.QuantidadeAutmovelDentroEstabelecimento(controleVeiculo);

                if (qtd > estabelecimento.QtdVagasCarros)
                {
                    _notificador.Add("ControleVeiculo", "O estabelecimento está lotado para vaga de automoveis.");
                    return false;
                }
            }
            else
            {
                int qtd = await _controleVeiculoRepository.QuantidadeMotoDentroEstabelecimento(controleVeiculo);

                if (qtd > estabelecimento.QtdVagasMotos)
                {
                    _notificador.Add("ControleVeiculo", "O estabelecimento está lotado para vaga de motos.");
                    return false;
                }
            }

            var controle = await _controleVeiculoRepository.VerificarVeiculoEstaDentroEstabelecimento(controleVeiculo);
            if (controle != null)
            {
                _notificador.Add("ControleVeiculo", "O veiculo já está dentro do estacionamento.");
                return false;
            }

            controleVeiculo.Id = Guid.NewGuid();
            controleVeiculo.DataHoraEntrada = DateTime.Now;
            controleVeiculo.DataHoraSaida = null;
            await   _controleVeiculoRepository.AdicionarAsync(controleVeiculo);
            return true;

        }


        public async Task<bool> SaidaVeiculoAsync(ControleVeiculo controleVeiculo, Estabelecimento estabelecimento)
        {
            var controle = await _controleVeiculoRepository.VerificarVeiculoEstaDentroEstabelecimento(controleVeiculo);
            if(controle == null)
            {
                _notificador.Add("ControleVeiculo", "O veiculo não está dentro do estabalecimento informado.");
                return false;
            }

            controle.DataHoraSaida = DateTime.Now;
           var controlAlterado = await _controleVeiculoRepository.AlterarAsync(controle);
           
            return true;

        }

    }
}
