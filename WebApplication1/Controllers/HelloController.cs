using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
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


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate Gender if it's provided
            if (student.Gender != null && student.Gender != "M" && student.Gender != "F")
            {
                return BadRequest("Invalid gender. Allowed values are 'M' or 'F'.");
            }

            try
            {
                // Add student to the database
                _sabaiClassContext.Student.Add(student);
                await _sabaiClassContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions related to database updates
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _sabaiClassContext.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null || id != student.Id)
            {
                return BadRequest("Student is null or ID mismatch.");
            }

            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate Gender if it's provided
            if (student.Gender != null && student.Gender != "M" && student.Gender != "F")
            {
                return BadRequest("Invalid gender. Allowed values are 'M' or 'F'.");
            }

            var existingStudent = await _sabaiClassContext.Student.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update the student's properties
            existingStudent.Name = student.Name;
            existingStudent.Gender = student.Gender;
            existingStudent.ClassName = student.ClassName;

            try
            {
                // Save changes to the database
                _sabaiClassContext.Entry(existingStudent).State = EntityState.Modified;
                await _sabaiClassContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return Ok(existingStudent);
        }

        // DELETE: api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _sabaiClassContext.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                // Remove the student from the database
                _sabaiClassContext.Student.Remove(student);
                await _sabaiClassContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }
    }
}
