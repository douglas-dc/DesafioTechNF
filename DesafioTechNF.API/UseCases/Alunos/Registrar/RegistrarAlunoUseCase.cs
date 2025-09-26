using DesafioTechNF.API.Domain;
using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.API.UseCases.Alunos.SharedValidator;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Communication.Responses;
using DesafioTechNF.Exceptions.ExceptionsBase;

namespace DesafioTechNF.API.UseCases.Alunos.Registrar
{
    public class RegistrarAlunoUseCase
    {
        public ResponseShortAlunoJson Executar(RequestAlunoJson request)
        {
            Validate(request);

            var dbContext = new DesafioTechNFDbContext();

            var entidade = new Aluno
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Plano = (PlanoTipo)request.Plano
            };

            dbContext.Alunos.Add(entidade);

            dbContext.SaveChanges();

            return new ResponseShortAlunoJson
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Plano = entidade.Plano.ToString()
            };
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