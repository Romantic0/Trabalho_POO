using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Data;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EmprestimoController(BibliotecaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            return await _context.Emprestimos
                .Include(e => e.Livro)
                .ThenInclude(l => l.Editora)
                .ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return emprestimo;
        }

        
        [HttpPost]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.Id }, emprestimo);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprestimo(int id, Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(emprestimo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
