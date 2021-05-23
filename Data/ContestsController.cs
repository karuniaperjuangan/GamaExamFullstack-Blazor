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
    public class ContestsController : ControllerBase
    {
        private readonly DBExamContext _context;

        public ContestsController(DBExamContext context)
        {
            _context = context;
        }

        // GET: api/Contests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contest>>> GetdContests()
        {
            return await _context.dContests.ToListAsync();
        }

        // GET: api/Contests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contest>> GetContest(int id)
        {
            var contest = await _context.dContests.FindAsync(id);

            if (contest == null)
            {
                return NotFound();
            }

            return contest;
        }

        // PUT: api/Contests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContest(int id, Contest contest)
        {
            if (id != contest.Id)
            {
                return BadRequest();
            }

            _context.Entry(contest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContestExists(id))
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

        // POST: api/Contests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contest>> PostContest(Contest contest)
        {
            _context.dContests.Add(contest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContest", new { id = contest.Id }, contest);
        }

        // DELETE: api/Contests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContest(int id)
        {
            var contest = await _context.dContests.FindAsync(id);
            if (contest == null)
            {
                return NotFound();
            }

            _context.dContests.Remove(contest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContestExists(int id)
        {
            return _context.dContests.Any(e => e.Id == id);
        }
    }
}
