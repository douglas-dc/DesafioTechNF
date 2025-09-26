using DesafioTechNF.Communication.Responses;
using DesafioTechNF.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioTechNF.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DesafioTechNFException desafioTechNFException)
            {
                context.HttpContext.Response.StatusCode = (int)desafioTechNFException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessagesJson(desafioTechNFException.GetErrors()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
        }
    }
}