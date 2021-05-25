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
    public class DParticipantsController : ControllerBase
    {
        private readonly DBExamContext _context;

        public DParticipantsController(DBExamContext context)
        {
            _context = context;
        }

        // GET: api/DParticipants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DParticipant>>> GetdParticipants()
        {
            return await _context.dParticipants.ToListAsync();
        }

        // GET: api/DParticipants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DParticipant>> GetDParticipant(int id)
        {
            var dParticipant = await _context.dParticipants.FindAsync(id);

            if (dParticipant == null)
            {
                return NotFound();
            }

            return dParticipant;
        }

        // GET: api/DCreators/username
        [HttpGet]
        [Route("getuser/{username}")]
        public async Task<ActionResult<DParticipant>> GetDParticipant(string username)
        {
            var dParticipant = await _context.dParticipants.Where(x => x.username == username).FirstAsync();

            if (dParticipant == null)
            {
                return NotFound();
            }

            return dParticipant;
        }

        // PUT: api/DParticipants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDParticipant(int id, DParticipant dParticipant)
        {
            if (id != dParticipant.Id)
            {
                return BadRequest();
            }

            _context.Entry(dParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DParticipantExists(id))
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

        // POST: api/DParticipants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DParticipant>> PostDParticipant(DParticipant dParticipant)
        {

            bool usernameAlreadyExists = _context.dParticipants.Any(x => x.username == dParticipant.username);
            if (usernameAlreadyExists == false)
            {
                _context.dParticipants.Add(dParticipant);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDParticipant", new { id = dParticipant.Id }, dParticipant);
            }
            else return BadRequest();

        }

        // DELETE: api/DParticipants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDParticipant(int id)
        {
            var dParticipant = await _context.dParticipants.FindAsync(id);
            if (dParticipant == null)
            {
                return NotFound();
            }

            _context.dParticipants.Remove(dParticipant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DParticipantExists(int id)
        {
            return _context.dParticipants.Any(e => e.Id == id);
        }
    }
}
