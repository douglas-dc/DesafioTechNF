using DesafioTechNF.API.Domain;
using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.API.UseCases.Aulas.SharedValidator;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Communication.Responses;
using DesafioTechNF.Exceptions.ExceptionsBase;

namespace DesafioTechNF.API.UseCases.Aulas.Registrar
{
    public class RegistrarAulaUseCase
    {
        public ResponseShortAulaJson Executar(RequestAulaJson request)
        {
            Validate(request);

            var dbContext = new DesafioTechNFDbContext();

            var entidade = new Aula
            {
                Id = Guid.NewGuid(),
                Modalidade = (AulaTipo)request.Modalidade,
                Horario = request.Horario,
                CapacidadeMaxima = request.CapacidadeMaxima
            };

            dbContext.Aulas.Add(entidade);

            dbContext.SaveChanges();

            return new ResponseShortAulaJson
            {
                Id = entidade.Id,
                Modalidade = entidade.Modalidade.ToString()
            };
        }

        private void Validate(RequestAulaJson request)
        {
            var validator = new RequestAulaValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }

        public ResponseAllAulasJson GetAll()
        {
            var dbContext = new DesafioTechNFDbContext();

            var aulas = dbContext.Aulas.ToList();

            return new ResponseAllAulasJson
            {
                Aulas = aulas.Select(aula => new ResponseShortAulaJson
                {
                    Id = aula.Id,
                    Modalidade = aula.Modalidade.ToString()
                }).ToList()
            };
        }
    }
}