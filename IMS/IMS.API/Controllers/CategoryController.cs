using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            this.categoryRepository = categoryRepository;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryRepository.ListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await this.categoryRepository.GetByIdAsync(id);
            if (category is null)
                return NotFound();
            
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
