using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        [HttpGet("{id?}")]
        public void Get([FromQuery] int? id)
        {

        }
        [HttpGet("{id?}/patrimonios")]
        public void GetPatrimonios([FromQuery] int? id)
        {

        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut("{id}")]
        public void Put([FromQuery] int id)
        {

        }

        [HttpDelete("{id}")]
        public void Delete([FromQuery] int id)
        {

        }
    }
}
