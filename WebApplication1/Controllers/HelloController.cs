using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/testing123")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly SabaiClassContext _sabaiClassContext;

        public HelloController(SabaiClassContext context)
        {
            _sabaiClassContext = context;
        }
  
        [HttpGet]
        public ActionResult<string> hello()
        {
            var students = _sabaiClassContext.Student.ToList();
            return Ok(students);
        }
    }
}
