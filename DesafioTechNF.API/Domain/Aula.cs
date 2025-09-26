namespace DesafioTechNF.API.Domain
{
    public class Aula
    {
        public Guid Id { get; set; }
        public  AulaTipo Modalidade { get; set; }
        public DateTime Horario { get; set; }
        public int CapacidadeMaxima { get; set; }

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }

    public enum AulaTipo
    {
        Musculacao = 0,
        Crossfit = 1,
        Funcional = 2,
        Pilates = 3
    }
}