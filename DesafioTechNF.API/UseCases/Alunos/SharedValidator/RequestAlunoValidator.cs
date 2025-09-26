using DesafioTechNF.Communication.Requests;
using FluentValidation;

namespace DesafioTechNF.API.UseCases.Alunos.SharedValidator
{
    public class RequestAlunoValidator : AbstractValidator<RequestAlunoJson>
    {
        public RequestAlunoValidator()
        {
            RuleFor(aluno => aluno.Nome).NotEmpty().WithMessage("O nome não pode ser vazio.");
        }
    }
}