using DesafioTechNF.Communication.Requests;
using FluentValidation;

namespace DesafioTechNF.API.UseCases.Aulas.SharedValidator
{
    public class RequestAulaValidator : AbstractValidator<RequestAulaJson>
    {
        public RequestAulaValidator()
        {
        }
    }
}