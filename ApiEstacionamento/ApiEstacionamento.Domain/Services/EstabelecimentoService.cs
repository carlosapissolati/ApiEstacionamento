using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Domain.Notificacoes;
using System;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {

        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        private readonly Notificador _notificador;

        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepository, Notificador notificador)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _notificador = notificador;
        }

        public async Task<Estabelecimento> BuscarEstabelecimentoIdAsync(Guid id)
        {

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorIdAsync(id);

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Estabelecimento", "Estabelecimento não encontrado com esse Id");
                return null;
            }
            return retornoEstabelecimento;

        }


        public async Task<Estabelecimento> AdicionarEstabelecimentoAsync(Estabelecimento estabelecimentoDTO)
        {
           

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorCnpjAsync(estabelecimentoDTO.CNPJ.ToString());
            if (retornoEstabelecimento != null)
            {
                _notificador.Add("Estabelecimento", "Já existe estabelecimento com esse CNPJ");
                return null;
            }

            

            var estab = await _estabelecimentoRepository.AdicionarAsync(estabelecimentoDTO);
            return estab;
        }


        public async Task<Estabelecimento> AlterarEstabelecimentoAsync(Estabelecimento estabelecimentoDTO)
        {

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorCnpjAsync(estabelecimentoDTO.CNPJ.ToString());

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Estabelecimento", "Não existe estabelecimento com esse CNPJ");
                return null;
            }

 

            var estab = await _estabelecimentoRepository.AlterarAsync(estabelecimentoDTO);
            return estab;
        }


        public async Task<Estabelecimento> DeletarEstabalecimento(Guid id)
        {

            Estabelecimento retornoEstabelecimento = await _estabelecimentoRepository.BuscarPorIdAsync(id);

            if (retornoEstabelecimento == null)
            {
                _notificador.Add("Estabelecimento", "Estabelecimento não encontrado com esse Id");
                return null;
            }

            await _estabelecimentoRepository.DeletarAsync(retornoEstabelecimento);

            return retornoEstabelecimento;

        }
    }
}
