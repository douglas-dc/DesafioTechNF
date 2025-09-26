namespace DesafioTechNF.Communication.Responses
{
    public class ResponseAlunoJson
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Plano { get; set; } = string.Empty;
        public List<ResponseShortAgendamentoJson> Agendamentos { get; set; } = [];
    }
}