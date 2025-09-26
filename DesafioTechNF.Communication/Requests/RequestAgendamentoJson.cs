namespace DesafioTechNF.Communication.Requests
{
    public class RequestAgendamentoJson
    {
        public Guid AlunoId { get; set; }
        public Guid AulaId { get; set; }
        public DateTime DataAgendamento { get; set; }
    }
}