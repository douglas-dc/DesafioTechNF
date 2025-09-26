using DesafioTechNF.Domain;
using DesafioTechNF.Domain.Exceptions;

namespace DesafioTechNF.Application
{
    public class AgendamentoService
    {
        private readonly IUnitOfWork _agendamentoService;

        public AgendamentoService(IUnitOfWork agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        public async Task AgendarAluno(Guid alunoId, Guid aulaId)
        {
            var aluno = await _agendamentoService.Alunos.GetByIdAsync(alunoId);
            var aula = await _agendamentoService.Aulas.GetByIdAsync(aulaId);

            if (aula.Agendamentos.Count >= aula.CapacidadeMaxima)
                throw new InvalidOperationException("A aula está lotada.");

            var agendamentosDoMes = aluno.Agendamentos
                .Where(a => a.Aula.Horario.Month == DateTime.Now.Month &&
                            a.Aula.Horario.Year == DateTime.Now.Year)
                .Count();

            var limite = PlanoException.ObterLimiteMensal(aluno.Plano);

            if (agendamentosDoMes >= limite)
                throw new InvalidOperationException("Limite de agendamentos do plano atingido.");

            var agendamento = new Agendamento
            {
                AlunoId = alunoId,
                AulaId = aulaId
            };

            _agendamentoService.Agendamentos.Add(agendamento);
            await _agendamentoService.CommitAsync();
        }
    }

}