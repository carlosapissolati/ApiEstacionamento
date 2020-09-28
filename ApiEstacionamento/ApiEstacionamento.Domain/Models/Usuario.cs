using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEstacionamento.Domain.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
