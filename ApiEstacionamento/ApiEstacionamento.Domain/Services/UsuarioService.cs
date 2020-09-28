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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Notificador _notificador;

        public UsuarioService(IUsuarioRepository usuarioRepository, Notificador notificador)
        {
            _usuarioRepository = usuarioRepository;
            _notificador = notificador;
        }

        public async Task AdicionarAsync ( Usuario usuarioDTO)
        {
            try
            {
                bool existe = await _usuarioRepository.PesquisarPorUserNameAsync(usuarioDTO);

                if (existe == false)
                {
                    _notificador.Add("Usuario", "Já existe um usuario com esse username");
                    return;
                }


                await _usuarioRepository.Adicionar(usuarioDTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<bool> LoginAsync(Usuario usuarioDTO)
        {
            try
            {
                bool login = await _usuarioRepository.Login(usuarioDTO);

                if(login == false)
                {
                    _notificador.Add("Usuario", "Usuario com a senha ou username incorreto.");
                }

                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
