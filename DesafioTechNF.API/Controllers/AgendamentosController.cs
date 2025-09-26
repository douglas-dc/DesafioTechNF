using DesafioTechNF.API.UseCases.Agendamentos.Registrar;
using DesafioTechNF.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechNF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Registrar([FromBody] RequestAgendamentoJson request)
        {
            var useCase = new RegistrarAgendamentoUseCase();

            useCase.Registrar(request.AlunoId, request.AulaId, request);

            return Ok("Agendamento realizado com sucesso!");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Relatorio(Guid id, [FromQuery] int mes, [FromQuery] int ano)
        {
            var useCase = new RegistrarAgendamentoUseCase();

            var response = useCase.GerarRelatorioAluno(id, ano, mes);

            return Ok(response);
        }
    }
}
