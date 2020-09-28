using ApiEstacionamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEstacionamento.Domain.Models
{
    public class Veiculo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EstabelecimentoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public ETipo Tipo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
