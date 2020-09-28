using ApiEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Interfaces.Service
{
    public  interface IControleVeiculoService
    {
        Task<bool> ControleVeiculoAsync(ControleVeiculo controleVeiculo);
    }
}
