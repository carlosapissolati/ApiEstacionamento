using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task AdicionarAsync(Usuario usuarioDTO);
        Task<bool> LoginAsync(Usuario usuarioDTO);
    }
}
