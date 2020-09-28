using ApiEstacionamento.Api.Configuration;
using ApiEstacionamento.Api.Extensions;
using ApiEstacionamento.Api.ViewModels;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Domain.Notificacoes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.Controllers
{
    [Produces("application/xml", "application/json")]
    public class UsuarioController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly Notificador _notificador;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IMapper mapper, IConfiguration configuration, Notificador notificador, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _notificador = notificador;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("v1/Login")]
        [AllowAnonymous]
        public async Task<ActionResult<ResultViewModel>> Login([FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));

                Usuario usuario = _mapper.Map<Usuario>(usuarioViewModel);

                bool result = await _usuarioService.LoginAsync(usuario);
                if (result == false)
                    return BadRequest(ModelError.GetErrorValidacao(_notificador));

                RetornoUsuarioViewModel retorno = new RetornoUsuarioViewModel();

                retorno.Usuario = usuarioViewModel.Username;
                retorno.Token = TokenJWTConfig.GenerateToken(usuarioViewModel.Username, _configuration["Key:DefaultKey"].ToString());


                ResultViewModel resultViewModel = new ResultViewModel(retorno);
                return Ok(resultViewModel);



            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("v1/Adicionar")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));

            Usuario usuario = _mapper.Map<Usuario>(usuarioViewModel);

            await _usuarioService.AdicionarAsync(usuario);

            if (_notificador.TemNotificacao())
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            usuario.Password = "**********";
            ResultViewModel resultViewModel = new ResultViewModel(usuario);
            return Ok(resultViewModel);
        }
    }
}
