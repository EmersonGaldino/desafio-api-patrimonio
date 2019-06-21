using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimoniosController : ControllerBase
    {
        private PatrimonioRepository _repository;

        public PatrimoniosController(IConfiguration configuration)
        {
            _repository = new PatrimonioRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.Get();

            if (result == null)
                return InternalServerError();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _repository.Get(id);

            if (result == null)
                return InternalServerError();

            if (result.NroTombo == -1)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Patrimonio patrimonio)
        {
            var validations = PostRequestValidation(patrimonio);
            if (validations != null) return validations;

            var result = _repository.Insert(patrimonio);

            if (result == null)
                return InternalServerError();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Patrimonio patrimonio)
        {
            var validations = PutRequestValidation(patrimonio);
            if (validations != null) return validations;

            var result = _repository.Update(id, patrimonio);

            if (result == 0)
                return NotFound();

            if (result == null)
                return InternalServerError();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _repository.Delete(id);

            if (result == 0)
                return NotFound();

            if (result == null)
                return InternalServerError();

            return Ok();
        }

        // Private methods
        private StatusCodeResult InternalServerError()
        {
            return StatusCode(500);
        }
        private IActionResult PostRequestValidation(Patrimonio patrimonio)
        {
            var errorMessage = string.Empty;

            if (patrimonio.MarcaId <= 0)
                errorMessage += "O campo MarcaId não foi preenchido corretamente! ";

            if (patrimonio.Nome == null)
                errorMessage += "O campo Nome não foi preenchido corretamente! ";

            if (errorMessage != string.Empty)
                return BadRequest(new { error = errorMessage });

            return null;
        }
        private IActionResult PutRequestValidation(Patrimonio patrimonio)
        {
            var fields = 0;

            if (patrimonio.Nome != null && patrimonio.Nome != string.Empty) fields++;
            if (patrimonio.Descricao != null && patrimonio.Descricao != string.Empty) fields++;
            if (patrimonio.MarcaId > 0) fields++;

            if (fields == 0)
                return BadRequest();

            return null;
        }
    }
}
