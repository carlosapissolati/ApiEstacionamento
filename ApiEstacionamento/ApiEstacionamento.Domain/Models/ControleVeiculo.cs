using ApiEstacionamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiEstacionamento.Domain.Models
{
    public class ControleVeiculo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EstabelecimentoId { get; set; }

        [ForeignKey("EstabelecimentoId")]
        public  virtual Estabelecimento estabelecimento { get; set; }
        public Guid VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public virtual Veiculo Veiculo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida{ get; set; }

        public int Tipo { get; set; }
        public int TipoControle { get; set; }
    }
}
