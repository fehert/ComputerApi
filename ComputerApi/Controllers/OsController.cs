using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Os>> Post(CreateOsDto createOsDto)
        {
            var os = new Os
            {
                Id = Guid.NewGuid(),
                Name = createOsDto.name,
            };
            if (os != null)
            {
                await computerContext.Os.AddAsync(os);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, os);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<Os>> Get()
        {
            return Ok(await computerContext.Os.ToListAsync());

        }
        [HttpGet("Id")]
        public async Task<ActionResult<Os>> Get(Guid Id)
        {
            return Ok(await computerContext.Os.FirstOrDefaultAsync(o => o.Id == Id));
        }
        [HttpPut]
        public async Task<ActionResult<Os>> Put(UpdateOsDto updateOsDto, Guid Id)
        {
            var existingos = await computerContext.Os.FirstOrDefaultAsync(o => o.Id == Id);
            if (existingos != null)
            {
                existingos.Name = updateOsDto.name;
                computerContext.Os.Update(existingos);
                computerContext.SaveChanges();
                return StatusCode(200, existingos);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult<Os>> Delete(Guid Id)
        {
            var existingos = await computerContext.Os.FirstOrDefaultAsync(o => o.Id == Id);
            if (existingos != null)
            {
                computerContext.Remove(existingos);
                computerContext.SaveChanges();
                return StatusCode(200);
            }
            return BadRequest();
        }
        [HttpGet("withallcomputer")]
        public async Task<ActionResult<Os>> GetWithAllComputer()
        {
            return Ok(await computerContext.Os.Include(os=>os.Comps).ToListAsync());
        }


    }
}

