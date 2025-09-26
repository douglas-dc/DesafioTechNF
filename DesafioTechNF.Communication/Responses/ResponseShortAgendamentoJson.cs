namespace DesafioTechNF.Communication.Responses
{
    public class ResponseShortAgendamentoJson
    {
        public Guid AgendamentoId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Modalidade { get; set; } = string.Empty;
        public DateTime Horario { get; set; }
    }
}