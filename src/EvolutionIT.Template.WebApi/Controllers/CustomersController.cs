using System.Collections.Generic;
using EvolutionIT.Template.Application.Interfaces;
using EvolutionIT.Template.Application.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EvolutionIT.Template.WebApi.Controllers
{
    [Route("api/[controller]")]    
    public class CustomersController : ControllerBase
    {
        private ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET api/customers
        [HttpGet]
        public IEnumerable<CustomerViewModel> Get()
        {
            return _customerAppService.GetAll();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerAppService.GetById(id);
            if (customer == null)
            {
                return NotFound("The customer was not found.");
            }

            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]CustomerViewModel customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerAppService.Add(customer);            

            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(customer.Id != id)
            {
                return BadRequest("Model id or url id invalid.");
            }

            var found = _customerAppService.Any(c => c.Id.Equals(id));
            if(!found)
            {
                return NotFound("The customer was not found.");
            }
            
            _customerAppService.Update(customer);            

            return NoContent();
        }

        // PATCH api/customers/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<CustomerViewModel> jsonPatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var originalCustomer = _customerAppService.GetByIdNoTracking(id);
            if (originalCustomer == null)
            {
                return NotFound("The customer was not found.");
            }
            
            jsonPatch.ApplyTo(originalCustomer, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerAppService.Update(originalCustomer);            

            return Ok(originalCustomer);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var found = _customerAppService.Any(c => c.Id.Equals(id));
            if (!found)
            {
                return NotFound("The customer was not found.");
            }

            _customerAppService.Remove(id);            

            return NoContent();
        }
    }
}
