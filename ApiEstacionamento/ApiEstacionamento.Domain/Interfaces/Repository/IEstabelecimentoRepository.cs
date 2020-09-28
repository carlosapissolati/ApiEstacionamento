
using ApiEstacionamento.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Repository
{
    public interface IEstabelecimentoRepository
    {
        Task<Estabelecimento> BuscarPorIdAsync(Guid id);
        Task<Estabelecimento> AdicionarAsync(Estabelecimento estabelecimento);
        Task<Estabelecimento> BuscarPorCnpjAsync(string cnpj);
        Task<Estabelecimento> AlterarAsync(Estabelecimento estabelecimento);
        Task<Estabelecimento> DeletarAsync(Estabelecimento estabelecimento);
    }
}
