using System.Net;

namespace DesafioTechNF.Exceptions.ExceptionsBase
{
    public class NotFoundException : DesafioTechNFException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErrors() => [Message];
       
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}