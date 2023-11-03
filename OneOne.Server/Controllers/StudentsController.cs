using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneOne.Server.Data;
using OneOne.Shared.Entities;
using OneOne.Shared.Models;

namespace OneOne.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            //return await _context.Students.Include(a=>a.Address).ToListAsync();
            return await (from s in _context.Students
                          select new StudentModel
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              Birthday = s.Birthday,
                              Email = s.Email,
                              Department = s.Department,
                              Street = s.Address.Street,
                              Barangay = s.Address.Barangay,
                              City = s.Address.City,
                              Province = s.Address.Province,
                              PostalCode = s.Address.PostalCode
                          }).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await (from s in _context.Students
                                 select new StudentModel
                                 {
                                     Id = s.Id,
                                     FirstName = s.FirstName,
                                     LastName = s.LastName,
                                     Gender = s.Gender,
                                     Birthday = s.Birthday,
                                     Email = s.Email,
                                     Department = s.Department,
                                     Street = s.Address.Street,
                                     Barangay = s.Address.Barangay,
                                     City = s.Address.City,
                                     Province = s.Address.Province,
                                     PostalCode = s.Address.PostalCode
                                 }).Where(d => d.Id == id).FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {

            if (_context.Students == null)
            {
                return Problem("Entity set 'DataContext.Students'  is null.");
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
