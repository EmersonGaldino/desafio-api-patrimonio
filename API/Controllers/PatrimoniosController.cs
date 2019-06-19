using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimoniosController : ControllerBase
    {
        [HttpGet("{id?}")]
        public void Get([FromQuery] int? id)
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
