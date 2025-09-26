namespace DesafioTechNF.Domain
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public PlanoTipo Plano { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }

    public enum PlanoTipo
    {
        Mensal,
        Trimestral,
        Anual
    }
}