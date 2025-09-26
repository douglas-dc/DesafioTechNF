namespace DesafioTechNF.Domain
{
    public class Aula
    {
        public Guid Id { get; set; }
        public  AulaTipo Modalidade { get; set; }
        public DateTime Horario { get; set; }
        public int CapacidadeMaxima { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }

    public enum AulaTipo
    {
        Musculacao,
        Crossfit,
        Funcional,
        Pilates
    }
}