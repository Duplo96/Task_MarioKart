using Microsoft.AspNetCore.Mvc;
using Task_MarioKart.DTO;
using Task_MarioKart.Services;

namespace Task_MarioKart.Controllers
{
    [Route("api/personaggi")]
    [ApiController]
    public class PersonaggiController : ControllerBase
    {
        private readonly PersonaggiService _service;

        public PersonaggiController(PersonaggiService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllPer());
        }

        [HttpPost("inserisci")]

        public IActionResult InserisciPersonaggio(PersonaggiDTO objPerso)
        {
            if (objPerso.Nom is not null && objPerso.Nom.Trim().Equals(""))
                return BadRequest();
            if (objPerso.Cat is not null && objPerso.Cat.Trim().Equals(""))
                return BadRequest();
            if (objPerso.Cos < 0)
                return BadRequest();

            if (_service.InserisciPersonaggio(objPerso))
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("elimina/{varCod}")]
        public ActionResult Delete(string varCod)
        {
            if (_service.EliminaPersonaggio(new PersonaggiDTO() { Cod = varCod }))
                return Ok();

            else
                return BadRequest();

        }

        [HttpPut("modifica")]
        public IActionResult ModificaPersonaggio(PersonaggiDTO objPer)
        {
            if (_service.ModificaPersonaggio(objPer))
                return Ok();
            return BadRequest();
        }


    
    }
}
