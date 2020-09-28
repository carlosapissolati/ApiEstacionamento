using ApiEstacionamento.Api.Extensions;
using ApiEstacionamento.Api.ViewModels;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Domain.Notificacoes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiEstacionamento.Api.Controllers
{
    [Authorize]
    public class EstacionamentoController : Controller
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;
        private readonly Notificador _notificador;
        private readonly IControleVeiculoService _controleVeiculoService;

        public EstacionamentoController(IEstabelecimentoService estabelecimentoService, IMapper mapper, Notificador notificador , IVeiculoService veiculoService, IControleVeiculoService controleVeiculoService)
        {
            _estabelecimentoService = estabelecimentoService;
            _mapper = mapper;
            _notificador = notificador;
            _veiculoService = veiculoService;
            _controleVeiculoService = controleVeiculoService;
        }

        [HttpGet]
        [Route("v1/estabelecimento/{id:Guid}")]
        public async Task<ActionResult<ResultViewModel>> BuscarEstabelecimentoId(Guid id)
        {
            try
            {

                Estabelecimento estabelecimento = await _estabelecimentoService.BuscarEstabelecimentoIdAsync(id);

                if (estabelecimento == null)
                {
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));
                }
                  

                var estabelecimentoViewModel = _mapper.Map<EstabelecimentoViewModel>(estabelecimento);

                ResultViewModel resultViewModel = new ResultViewModel(estabelecimentoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }

        }


        [HttpPost]
        [Route("v1/estabelecimento")]
        public async Task<ActionResult> AdicionarEstabelecimentoAsync([FromBody] EstabelecimentoViewModel estabelecimento)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState,_notificador)));


                var estabelecimentoDto = _mapper.Map<Estabelecimento>(estabelecimento);


                var retornoEstabelecimento = await _estabelecimentoService.AdicionarEstabelecimentoAsync(estabelecimentoDto);

                if (retornoEstabelecimento == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));
                
                   
                var estabelecimentoViewModel = _mapper.Map<EstabelecimentoViewModel>(retornoEstabelecimento);

                ResultViewModel resultViewModel = new ResultViewModel(estabelecimentoViewModel);

                return Ok(resultViewModel);
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }



        [HttpPut]
        [Route("v1/estabelecimento")]
        public async Task<ActionResult<ResultViewModel>> AlterarEstabelecimentoAsync([FromBody] EstabelecimentoViewModel estabelecimento)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));


                var estabelecimentoDto = _mapper.Map<Estabelecimento>(estabelecimento);


                var retornoEstabelecimento = await _estabelecimentoService.AlterarEstabelecimentoAsync(estabelecimentoDto);

                if (retornoEstabelecimento == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));

                var estabelecimentoViewModel = _mapper.Map<EstabelecimentoViewModel>(retornoEstabelecimento);

                ResultViewModel resultViewModel = new ResultViewModel(estabelecimentoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("v1/estabelecimento/{id:Guid}")]
        public async Task<ActionResult<ResultViewModel>> DeletarEstabalecimentoAsync(Guid Id)
        {
            try
            {

                var retornoEstabelecimento = await _estabelecimentoService.DeletarEstabalecimento(Id);

                if (retornoEstabelecimento == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));

                var estabelecimentoViewModel = _mapper.Map<EstabelecimentoViewModel>(retornoEstabelecimento);

                ResultViewModel resultViewModel = new ResultViewModel(estabelecimentoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("v1/veiculo/{id:Guid}")]
        public async Task<ActionResult<ResultViewModel>> BuscarVeiculoId(Guid id)
        {
            try
            {
                var retornoVeiculo = await _veiculoService.BuscarVeiculoIdAsync(id);

                if (retornoVeiculo == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));


                var veiculoViewModel = _mapper.Map<VeiculoViewModel>(retornoVeiculo);

                ResultViewModel resultViewModel = new ResultViewModel(veiculoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }


        [HttpPost]
        [Route("v1/veiculo")]
        public async Task<ActionResult<ResultViewModel>> AdicionarVeiculoAsync([FromBody] VeiculoViewModel veiculo)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));


                var veiculoDTO = _mapper.Map<Veiculo>(veiculo);


                var retornoVeiculo = await _veiculoService.AdicionarVeiculoAsync(veiculoDTO);

                if (retornoVeiculo == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));


                var veiculoViewModel = _mapper.Map<VeiculoViewModel>(retornoVeiculo);

                ResultViewModel resultViewModel = new ResultViewModel(veiculoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }


        [HttpPut]
        [Route("v1/veiculo")]
        public async Task<ActionResult<ResultViewModel>> AlterarVeiculoAsync([FromBody] VeiculoViewModel veiculo)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));


                var veiculoDTO = _mapper.Map<Veiculo>(veiculo);


                var retornoVeiculo = await _veiculoService.AlterarVeiculoAsync(veiculoDTO);

                if (retornoVeiculo == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));

                var veiculoViewModel = _mapper.Map<VeiculoViewModel>(retornoVeiculo);

                ResultViewModel resultViewModel = new ResultViewModel(veiculoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }


        [HttpDelete]
        [Route("v1/veiculo/{id:Guid}")]
        public async Task<ActionResult<ResultViewModel>> DeletarVeiculoAsync(Guid Id)
        {
            try
            {

                var retornoVeiculo = await _veiculoService.DeletarVeiculo(Id);

                if (retornoVeiculo == null)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));

                var veiculoViewModel = _mapper.Map<VeiculoViewModel>(retornoVeiculo);

                ResultViewModel resultViewModel = new ResultViewModel(veiculoViewModel);
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }


        [HttpPost]
        [Route("v1/veiculo/controle")]
        public async Task<ActionResult<ResultViewModel>> EntradaVeiculoAsync([FromBody] ControleViewModel controle)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel(ModelError.GetErrorModelState(ModelState, _notificador)));


                var controleVeiculo = _mapper.Map<ControleVeiculo>(controle);


                bool sucesso = await _controleVeiculoService.ControleVeiculoAsync(controleVeiculo);

                if (sucesso == false)
                    return BadRequest(new ResultViewModel(_notificador.ObterNotificacoes()));


                ResultViewModel resultViewModel = new ResultViewModel("Sucesso");
                return Ok(resultViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }
    }
}
