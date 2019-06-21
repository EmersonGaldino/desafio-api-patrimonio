using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private MarcaRepository _repository;

        public MarcasController(IConfiguration configuration)
        {
            _repository = new MarcaRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.Get();

            if(result == null)
                return InternalServerError();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _repository.Get(id);

            if (result == null)
                return InternalServerError();

            if (result.MarcaId == -1)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}/patrimonios")]
        public IActionResult GetPatrimonios([FromRoute] int id)
        {
            var result = _repository.GetPatrimonio(id);

            if (result == null)
                return InternalServerError();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Marca marca)
        {
            var validations = PostRequestValidation(marca);
            if (validations != null) return validations;

            var result = _repository.Insert(marca);

            if (result == null)
                return InternalServerError();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Marca marca)
        {
            var validations = PutRequestValidation(marca);
            if (validations != null) return validations;

            var result = _repository.Update(id, marca);

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
        private IActionResult PostRequestValidation(Marca marca)
        {
            var errorMessage = string.Empty;

            if (marca.Nome == null || marca.Nome == string.Empty)
                errorMessage += "O campo Nome não foi preenchido corretamente! ";

            if (errorMessage != string.Empty)
                return BadRequest(new { error = errorMessage });

            return null;
        }
        private IActionResult PutRequestValidation(Marca marca)
        {
            if (marca.Nome == null || marca.Nome == string.Empty) 
                return BadRequest();

            return null;
        }
    }
}
