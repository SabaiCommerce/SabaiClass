using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<Student> Get()
        {
            var student = new Student
            {
                Name = "A" // Example name
            };

            return student;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
