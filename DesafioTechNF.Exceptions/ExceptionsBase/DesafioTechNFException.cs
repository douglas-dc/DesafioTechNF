using System.Net;

namespace DesafioTechNF.Exceptions.ExceptionsBase
{
    public abstract class DesafioTechNFException : SystemException
    {
        public DesafioTechNFException(string errorMessage) : base(errorMessage)
        {
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
