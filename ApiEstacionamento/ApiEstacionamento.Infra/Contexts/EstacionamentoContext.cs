using ApiEstacionamento.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEstacionamento.Infra.Contexts
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options) : base(options) { }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ControleVeiculo> ControleVeiculo { get; set; }


    }
}
