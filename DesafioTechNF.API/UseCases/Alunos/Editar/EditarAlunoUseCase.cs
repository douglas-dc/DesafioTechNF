using DesafioTechNF.API.Domain;
using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.API.UseCases.Alunos.Registrar;
using DesafioTechNF.API.UseCases.Alunos.SharedValidator;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Exceptions.ExceptionsBase;

namespace DesafioTechNF.API.UseCases.Alunos.Editar
{
    public class EditarAlunoUseCase
    {
        public void Editar(Guid alunoId, RequestAlunoJson request)
        {
            Validate(request);

            var dbContext = new DesafioTechNFDbContext();

            var entidade = dbContext.Alunos.FirstOrDefault(aluno => aluno.Id == alunoId);

            if (entidade is null)
                throw new NotFoundException("Aluno não encontrado.");

            entidade.Nome = request.Nome;
            entidade.Plano = (PlanoTipo)request.Plano;

            dbContext.Alunos.Update(entidade);

            dbContext.SaveChanges();
        }

        private void Validate(RequestAlunoJson request)
        {
            var validator = new RequestAlunoValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}