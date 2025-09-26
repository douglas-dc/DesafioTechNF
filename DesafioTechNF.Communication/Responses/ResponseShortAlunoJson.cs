namespace DesafioTechNF.Communication.Responses
{
    public class ResponseShortAlunoJson
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Plano { get; set; } = string.Empty;
    }
}