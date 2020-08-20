using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DataService.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alef_Vinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesDbContext db;

        public ValuesController(ValuesDbContext context)
        {
            db = context;
            if (!db.Values.Any())
            {
                db.Values.Add(new Value { Name = "Bilain", Description = "091" });
                db.Values.Add(new Value { Name = "MTS", Description = "068" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            return await db.Values.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            Value value = await db.Values.FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
                return NotFound();
            return new ObjectResult(value);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Value>> Post(Value value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            db.Values.Add(value);
            await db.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Value>> Put(Value value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if (!db.Values.Any(x => x.Id == value.Id))
            {
                return NotFound();
            }

            db.Update(value);
            await db.SaveChangesAsync();
            return Ok(value);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Value>> Delete(int id)
        {
            Value value = db.Values.FirstOrDefault(x => x.Id == id);
            if (value == null)
            {
                return NotFound();
            }
            db.Values.Remove(value);
            await db.SaveChangesAsync();
            return Ok(value);
        }
    }
}
