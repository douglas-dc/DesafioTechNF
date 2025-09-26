namespace DesafioTechNF.API.Domain
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public PlanoTipo Plano { get; set; }

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }

    public enum PlanoTipo
    {
        Mensal = 0,
        Trimestral = 1,
        Anual = 2
    }
}