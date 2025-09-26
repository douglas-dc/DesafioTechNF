using DesafioTechNF.API.Infrastructure;
using DesafioTechNF.Exceptions.ExceptionsBase;

namespace DesafioTechNF.API.UseCases.Alunos.Deletar
{
    public class DeletarAlunoUseCase
    {
        public void Deletar(Guid id)
        {
            var dbContext = new DesafioTechNFDbContext();

            var entidade = dbContext.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (entidade is null)
                throw new NotFoundException("Aluno não encontrado.");

            dbContext.Alunos.Remove(entidade);

            dbContext.SaveChanges();
        }
    }
}