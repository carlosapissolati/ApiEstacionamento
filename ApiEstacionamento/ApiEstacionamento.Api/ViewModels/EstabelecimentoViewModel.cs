using ApiEstacionamento.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Api.ViewModels
{
    public class EstabelecimentoViewModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A QtdVagasMotos precisa ser maior que 0")]
        public int QtdVagasMotos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A QtdVagasCarros precisa ser maior que 0")]
        public int QtdVagasCarros { get; set; }
    }
}
