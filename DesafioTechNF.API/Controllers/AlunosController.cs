using DesafioTechNF.API.UseCases.Alunos.Deletar;
using DesafioTechNF.API.UseCases.Alunos.Editar;
using DesafioTechNF.API.UseCases.Alunos.GetAll;
using DesafioTechNF.API.UseCases.Alunos.RecuperarPorId;
using DesafioTechNF.API.UseCases.Alunos.Registrar;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechNF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortAlunoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromBody]RequestAlunoJson request)
        {
            var useCase = new RegistrarAlunoUseCase();

            var response = useCase.Executar(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] RequestAlunoJson request)
        {
            var useCase = new EditarAlunoUseCase();

            useCase.Editar(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllAlunosJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllAlunoUseCase();

            var response = useCase.GetAll();

            if (response.Alunos.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAlunoJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new RecuperarPorIdAlunoUseCase();

            var response = useCase.RecuperarPorId(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Deletar([FromRoute] Guid id)
        {
            var useCase = new DeletarAlunoUseCase();

            useCase.Deletar(id);

            return NoContent();
        }
    }
}