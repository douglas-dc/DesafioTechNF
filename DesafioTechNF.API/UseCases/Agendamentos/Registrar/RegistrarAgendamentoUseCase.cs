using DesafioTechNF.API.Domain;
using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Communication.Responses;

namespace DesafioTechNF.API.UseCases.Agendamentos.Registrar
{
    public class RegistrarAgendamentoUseCase
    {
        public void Registrar(Guid alunoId, Guid aulaId, RequestAgendamentoJson request)
        {
            var dbContext = new DesafioTechNFDbContext();

            var aluno = dbContext.Alunos.FirstOrDefault(a => a.Id == alunoId)
                ?? throw new ArgumentException("Aluno não encontrado.");

            var aula = dbContext.Aulas.FirstOrDefault(a => a.Id == aulaId)
                ?? throw new ArgumentException("Aula não encontrada.");

            var totalAgendados = dbContext.Agendamentos.Count(a => a.AulaId == aulaId);
            if (totalAgendados >= aula.CapacidadeMaxima)
                throw new InvalidOperationException("Aula já atingiu a capacidade máxima.");

            var inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var fimMes = inicioMes.AddMonths(1).AddTicks(-1);

            var agendamentosAlunoNoMes = dbContext.Agendamentos
                .Count(a => a.AlunoId == alunoId &&
                            a.DataAgendamento >= inicioMes &&
                            a.DataAgendamento <= fimMes);

            int limitePlano = aluno.Plano switch
            {
                PlanoTipo.Mensal => 12,
                PlanoTipo.Trimestral => 20,
                PlanoTipo.Anual => 30,
                _ => throw new InvalidOperationException("Plano inválido.")
            };

            if (agendamentosAlunoNoMes >= limitePlano)
                throw new InvalidOperationException($"Aluno já atingiu o limite mensal do plano ({limitePlano} aulas).");

            var entidade = new Agendamento
            {
                Id = Guid.NewGuid(),
                AlunoId = alunoId,
                AulaId = aulaId,
                DataAgendamento = DateTime.Now
            };

            dbContext.Agendamentos.Add(entidade);

            dbContext.SaveChanges();
        }

        public ResponseRelatorioJson GerarRelatorioAluno(Guid alunoId, int ano, int mes)
        {
            using var dbContext = new DesafioTechNFDbContext();

            var aluno = dbContext.Alunos.FirstOrDefault(a => a.Id == alunoId)
                ?? throw new ArgumentException("Aluno não encontrado.");

            var inicioMes = new DateTime(ano, mes, 1);
            var fimMes = inicioMes.AddMonths(1).AddTicks(-1);

            //Agendamentos do aluno no mês
            var agendamentos = dbContext.Agendamentos
                .Where(a => a.AlunoId == alunoId &&
                            a.DataAgendamento >= inicioMes &&
                            a.DataAgendamento <= fimMes)
                .Join(dbContext.Aulas,
                      ag => ag.AulaId,
                      au => au.Id,
                      (ag, au) => au) //retorna a aula
                .ToList();

            var total = agendamentos.Count;

            //Agrupar por tipo de aula e ordenar pelos mais frequentes
            var modalidadesMaisFrequentes = agendamentos
                .GroupBy(a => a.Modalidade.ToString())
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();

            return new ResponseRelatorioJson
            {
                TotalAulasNoMes = total,
                ModalidadesMaisFrequentes = modalidadesMaisFrequentes
            };
        }
    }
}