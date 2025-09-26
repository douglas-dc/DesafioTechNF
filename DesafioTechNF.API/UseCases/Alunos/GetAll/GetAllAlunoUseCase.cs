using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.Communication.Responses;

namespace DesafioTechNF.API.UseCases.Alunos.GetAll
{
    public class GetAllAlunoUseCase
    {
        public ResponseAllAlunosJson GetAll()
        {
            var dbContext = new DesafioTechNFDbContext();

            var alunos = dbContext.Alunos.ToList();

            return new ResponseAllAlunosJson
            {
                Alunos = alunos.Select(aluno => new ResponseShortAlunoJson
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Plano = aluno.Plano.ToString(),
                }).ToList()
            };
        }
    }
}