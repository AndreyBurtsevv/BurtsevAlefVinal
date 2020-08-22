using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlefVinalServices.Services;
using DataService;
using DataService.DataModels;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alef_Vinal.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValueService service;

        public ValuesController(IValueService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IEnumerable<Value>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            Value value = await service.GetAsync(id);
            if (value == null)
                return NotFound();
            return new ObjectResult(value);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Value>> Post(Value value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            await service.CreateAsync(value);
            return Ok(value);
        }

        // PUT
        [HttpPut]
        public async Task<ActionResult<Value>> Put(Value value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            await service.UpdateAsync(value);
            return Ok(value);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Value>> Delete(int id)
        {
            Value result = await service.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
    }
}
