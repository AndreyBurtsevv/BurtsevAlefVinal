using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlefVinalServices.Filters;
using AlefVinalServices.Services;
using DataService;
using DataService.DataModels;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alef_Vinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            try
            {
                Value value = await service.GetAsync(id);
                return new ObjectResult(value);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }            
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Value>> Post(Value value)
        {
            try
            {                
                await service.CreateAsync(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }  
        }

        // PUT
        //[Route("{id}")]
        [IdFilter]
        [HttpPut]  
        public async Task<ActionResult<Value>> Put(Value value)
        { 
            try
            {
                await service.UpdateAsync(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Value>> Delete(int id)
        {
            try
            {
                Value result = await service.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }           
        }
    }
}
