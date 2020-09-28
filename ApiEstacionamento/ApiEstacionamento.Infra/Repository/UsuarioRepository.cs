using ApiEstacionamento.Domain.Interfaces.Repository;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EstacionamentoContext _estacionamentoContext;

        public UsuarioRepository(EstacionamentoContext estacionamentoContext)
        {
            _estacionamentoContext = estacionamentoContext;
        }

        public async Task Adicionar(Usuario usuario)
        {
            try
            {
                _estacionamentoContext.Usuarios.Add(usuario);
                await _estacionamentoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> PesquisarPorUserNameAsync(Usuario usuario)
        {
            try
            {


                var u = await _estacionamentoContext.Usuarios.FirstOrDefaultAsync(u => u.Username ==usuario.Username);
                if (u == null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Login(Usuario usuario)
        {
            try
            {
                bool sucesso = false;

                var u = await _estacionamentoContext.Usuarios.FirstOrDefaultAsync(u => u.Password == usuario.Password && u.Username == usuario.Username);

                if (u != null)
                    sucesso = true;

                return sucesso;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
