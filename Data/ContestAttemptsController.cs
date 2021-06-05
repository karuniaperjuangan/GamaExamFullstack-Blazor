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
    public class ContestAttemptsController : ControllerBase
    {
        private readonly DBExamContext _context;

        public ContestAttemptsController(DBExamContext context)
        {
            _context = context;
        }

        // GET: api/ContestAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContestAttempt>>> GetdContestsAttempt()
        {
            return await _context.dContestsAttempt.ToListAsync();
        }

        // GET: api/ContestAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContestAttempt>> GetContestAttempt(int id)
        {
            var contestAttempt = await _context.dContestsAttempt.FindAsync(id);

            if (contestAttempt == null)
            {
                return NotFound();
            }

            return contestAttempt;
        }

        // PUT: api/ContestAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContestAttempt(int id, ContestAttempt contestAttempt)
        {
            if (id != contestAttempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(contestAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContestAttemptExists(id))
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

        // POST: api/ContestAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<int> PostContestAttempt(ContestAttempt contestAttempt)
        {
            contestAttempt.Contest = await _context.dContests.FindAsync(contestAttempt.ContestId);
            contestAttempt.Participant = await _context.dParticipants.FindAsync(contestAttempt.ParticipantId);
            _context.dContestsAttempt.Add(contestAttempt);
            await _context.SaveChangesAsync();

            CreatedAtAction("GetContestAttempt", new { id = contestAttempt.Id }, contestAttempt);
            return contestAttempt.Id;
        }

        // DELETE: api/ContestAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContestAttempt(int id)
        {
            var contestAttempt = await _context.dContestsAttempt.FindAsync(id);
            if (contestAttempt == null)
            {
                return NotFound();
            }

            _context.dContestsAttempt.Remove(contestAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContestAttemptExists(int id)
        {
            return _context.dContestsAttempt.Any(e => e.Id == id);
        }
    }
}
