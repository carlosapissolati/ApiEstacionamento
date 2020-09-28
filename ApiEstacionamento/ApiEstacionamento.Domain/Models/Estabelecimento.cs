using ApiEstacionamento.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ApiEstacionamento.Domain.Models
{
    public class Estabelecimento
    {
        [Key]
        public Guid Id { get; set; }
        public string CNPJ { get; set; } 
        public string Endereco { get; set; }  
        public string Telefone { get; set; }  
        public int QtdVagasMotos { get; set; }  
        public int QtdVagasCarros { get; set; }  
        public DateTime DataCriacao { get; set; }


        public Veiculo Veiculos { get; set; }
    }
}
