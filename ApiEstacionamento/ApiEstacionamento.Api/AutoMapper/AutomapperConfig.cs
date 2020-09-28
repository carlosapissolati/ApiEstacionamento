using ApiEstacionamento.Api.ViewModels;
using ApiEstacionamento.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Estabelecimento, EstabelecimentoViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<ControleVeiculo, ControleViewModel>().ReverseMap();
            CreateMap<QtdEntradaSaidaHora, RelatorioQtdEntradaSaidaHoraViewModel>().ReverseMap();
        }
    }
}
