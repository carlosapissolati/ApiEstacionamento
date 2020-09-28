using ApiEstacionamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.ViewModels
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }
        public Guid EstabelecimentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 7)]
        public string Placa { get; set; }

        public ETipo Tipo { get; set; }
    }
}
