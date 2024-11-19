using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComputerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public OsController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }
        [HttpPost]
        public ActionResult<Os> Post(CreateOsDto createOsDto)
        {
            var os = new Os
            {
                Id = Guid.NewGuid(),
                Name = createOsDto.name,
            };
            if (os != null)
            {
                computerContext.Os.Add(os);
                computerContext.SaveChanges();
                return StatusCode(201, os);
            }
            return BadRequest();
        }
    }
}
