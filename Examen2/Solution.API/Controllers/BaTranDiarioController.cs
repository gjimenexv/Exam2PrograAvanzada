using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = Solution.DO.Objects;
using Solution.BS;
using Solution.DAL.EF;

namespace Examen2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaTranDiariosController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public BaTranDiariosController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/BaTranDiarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.BaTranDiario>>> GetBaTranDiario()
        {
            return new BaTranDiario(_context).GetAll().ToList();
        }

        // GET: api/BaTranDiarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.BaTranDiario>> GetBaTranDiario(string id)
        {
            var batrandiario = new BaTranDiario(_context).GetOneById(id);

            if (batrandiario == null)
            {
                return NotFound();
            }

            return batrandiario;
        }

        // PUT: api/BaTranDiarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaTranDiario(string id, data.BaTranDiario batrandiario)
        {
            if (id.ToString() != batrandiario.CodEmpresa)
            {
                return BadRequest();
            }

            // _context.Entry(batrandiario).State = EntityState.Modified;

            try
            {
                new BaTranDiario(_context).Updated(batrandiario);
            }
            catch (Exception ee)
            {
                throw ee;
            }

            return NoContent();
      
        }

        // POST: api/BaTranDiarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.BaTranDiario>> PostBaTranDiario(data.BaTranDiario baTranDiario)
        {
            new BaTranDiario(_context).Insert(baTranDiario);
            return CreatedAtAction("GetBaTranDiario", new { id = baTranDiario.CodEmpresa }, baTranDiario);
        }


        // DELETE: api/BaTranDiarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.BaTranDiario>> DeleteBaTranDiario(string id)
        {
            var batrandiario = new BaTranDiario(_context).GetOneById(id);
            if (batrandiario == null)
            {
                return NotFound();
            }

            new BaTranDiario(_context).Delete(batrandiario);
            await _context.SaveChangesAsync();

            return batrandiario;
        }

        private bool BaTranDiarioExists(string id)
        {
            return _context.batrandiario.Any(e => e.CodEmpresa == id);
        }
    }
}
