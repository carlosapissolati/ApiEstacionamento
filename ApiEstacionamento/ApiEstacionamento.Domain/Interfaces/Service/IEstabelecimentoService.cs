using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Service
{
    public interface IEstabelecimentoService
    {
        Task<Estabelecimento> BuscarEstabelecimentoIdAsync(Guid id);
        Task<Estabelecimento> AdicionarEstabelecimentoAsync(Estabelecimento estabelecimento);
        Task<Estabelecimento> AlterarEstabelecimentoAsync(Estabelecimento estabelecimentoDTO);

        Task<Estabelecimento> DeletarEstabalecimento(Guid id);
    }
}
