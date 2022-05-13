using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProdutosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post()
        {
            return null;
        }

        [HttpPut]
        public IActionResult Put()
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return null;
        }
    }
}
