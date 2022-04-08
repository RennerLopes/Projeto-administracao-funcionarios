using Microsoft.EntityFrameworkCore;
using SixConsult.Funcionarios.Classes;

namespace SixConsult.Funcionarios.Web.Data
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {
        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}