using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.Communication.Responses;
using DesafioTechNF.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechNF.API.UseCases.Alunos.RecuperarPorId
{
    public class RecuperarPorIdAlunoUseCase
    {
        public ResponseAlunoJson RecuperarPorId(Guid id)
        {
            var dbContext = new DesafioTechNFDbContext();

            var entidade = dbContext.Alunos.Include(aluno => aluno.Agendamentos)
                .ThenInclude(ag => ag.Aula)
                .FirstOrDefault(aluno => aluno.Id == id);
            if (entidade is null)
                throw new NotFoundException("Aluno não encontrado.");

            return new ResponseAlunoJson
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Plano = entidade.Plano.ToString(),
                Agendamentos = entidade.Agendamentos.Select(ag => new ResponseShortAgendamentoJson
                {
                    AgendamentoId = ag.Id,
                    DataAgendamento = ag.DataAgendamento,
                    Modalidade = ag.Aula.Modalidade.ToString(),
                    Horario = ag.Aula.Horario
                }).ToList()
            };
        }
    }
}