namespace DesafioTechNF.Domain
{
    public class Agendamento
    {
        public Guid Id { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public Guid AulaId { get; set; }
        public Aula Aula { get; set; }

        public DateTime DataAgendamento { get; set; } = DateTime.Now;
    }
}