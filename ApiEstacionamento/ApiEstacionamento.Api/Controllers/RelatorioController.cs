using ApiEstacionamento.Api.Extensions;
using ApiEstacionamento.Api.ViewModels;
using ApiEstacionamento.Domain.Interfaces.Service;
using ApiEstacionamento.Domain.Models;
using ApiEstacionamento.Domain.Notificacoes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.Controllers
{
    [Authorize]
    public class RelatorioController :  Controller
    {

        private readonly IRelatorioService _relatorioService;
        private readonly IMapper _mapper;
        private readonly Notificador _notificador;

        public RelatorioController(IRelatorioService relatorioService, IMapper mapper, Notificador notificador)
        {
            _relatorioService = relatorioService;
            _mapper = mapper;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("v1/RelatorioEntradaSaidaVeiculoHora/{id:Guid}")]
        public async Task<ActionResult<List<RelatorioQtdEntradaSaidaHoraViewModel>>> RelatorioEntradaSaidaVeiculoHoraAsync(Guid id)
        {
            try
            {
                List<QtdEntradaSaidaHora> result = await _relatorioService.QtdEntradaSaidaHoraDTO(id);

                if (result == null)
                    return BadRequest(ModelError.GetErrorValidacao(_notificador));


                List<RelatorioQtdEntradaSaidaHoraViewModel> relatorioQtdEntradaSaidaHoraViewModel = _mapper.Map<List<RelatorioQtdEntradaSaidaHoraViewModel>>(result);

                return Ok(relatorioQtdEntradaSaidaHoraViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }

    }
}
