using Microsoft.AspNetCore.Mvc;
using Task_MarioKart.DTO;
using Task_MarioKart.Services;

namespace Task_MarioKart.Controllers
{
    [Route("api/squadre")]
    [ApiController]
    public class SquadraController : ControllerBase
    {
        private readonly SquadraService _service;

        public SquadraController(SquadraService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllSqua());
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciSquadra(SquadraDTO objSq)
        {
            if (_service.InserisciSquadra(objSq))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("modifica")]
        public IActionResult ModificaSquadra(SquadraDTO objSq)
        {
            if (_service.ModificaSquadra(objSq))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("elimina/{varCod}")]
        public ActionResult Delete(string varCod)
        {
            if (_service.EliminaSquadra(new SquadraDTO() { Codice = varCod }))
                return Ok();

            else
                return BadRequest();

        }


        [HttpPost("InsInSquad/{codSquad}/{codPer}")]

        public IActionResult InserisciInSquadra( string codPer, string codSqua)
        {
            if (_service.InsertPersonaggio(codPer,codSqua))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
