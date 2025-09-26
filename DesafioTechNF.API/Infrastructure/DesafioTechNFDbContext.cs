using DesafioTechNF.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechNF.API.Infrastructure
{
    public class DesafioTechNFDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Douglas\\Documents\\DB\\desafiotechnfdb.db");
        }
    }
}