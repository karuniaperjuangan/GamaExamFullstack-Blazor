using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamaExamFullstack.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCreatorsController : ControllerBase
    {
        private readonly DBExamContext _context;

        public DCreatorsController(DBExamContext context)
        {
            _context = context;
        }

        // GET: api/DCreators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCreator>>> GetdCreators()
        {
            return await _context.dCreators.ToListAsync();
        }

        // GET: api/DCreators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCreator>> GetDCreator(int id)
        {
            var dCreator = await _context.dCreators.FindAsync(id);

            if (dCreator == null)
            {
                return NotFound();
            }

            return dCreator;
        }

        // GET: api/DCreators/username
        [HttpGet]
        [Route("getuser/{username}")]
        public async Task<ActionResult<DCreator>> GetDCreator(string username)
        {
            var dCreator = await _context.dCreators.Where(x => x.username == username).FirstAsync();

            if (dCreator == null)
            {
                return NotFound();
            }

            return dCreator;
        }

        // PUT: api/DCreators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCreator(int id, DCreator dCreator)
        {
            if (id != dCreator.Id)
            {
                return BadRequest();
            }

            _context.Entry(dCreator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCreatorExists(id))
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

        // POST: api/DCreators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DCreator>> PostDCreator(DCreator dCreator)
        {
            bool usernameAlreadyExists = _context.dCreators.Any(x => x.username == dCreator.username);
            if(usernameAlreadyExists == false)
            {
            _context.dCreators.Add(dCreator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCreator", new { id = dCreator.Id }, dCreator);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/DCreators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDCreator(int id)
        {
            var dCreator = await _context.dCreators.FindAsync(id);
            if (dCreator == null)
            {
                return NotFound();
            }

            _context.dCreators.Remove(dCreator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DCreatorExists(int id)
        {
            return _context.dCreators.Any(e => e.Id == id);
        }
    }
}
