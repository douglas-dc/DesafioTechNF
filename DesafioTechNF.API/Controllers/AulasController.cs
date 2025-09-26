using DesafioTechNF.API.UseCases.Aulas.Registrar;
using DesafioTechNF.Communication.Requests;
using DesafioTechNF.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechNF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortAulaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromBody] RequestAulaJson request)
        {
            var useCase = new RegistrarAulaUseCase();

            var response = useCase.Executar(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllAulasJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new RegistrarAulaUseCase();

            var response = useCase.GetAll();

            if (response.Aulas.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
