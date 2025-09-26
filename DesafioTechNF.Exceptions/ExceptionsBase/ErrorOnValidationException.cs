using System.Net;

namespace DesafioTechNF.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : DesafioTechNFException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorsMessage) : base(string.Empty)
        {
            _errors = errorsMessage;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}