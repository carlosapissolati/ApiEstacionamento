using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task Adicionar(Usuario usuario);
        Task<bool> Login(Usuario usuario);

        Task<bool> PesquisarPorUserNameAsync(Usuario usuario);
    }
}
