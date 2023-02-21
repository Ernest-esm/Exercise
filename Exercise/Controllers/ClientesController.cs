using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercise.Data;
using Exercise.Models;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ExerciseContext _context;

        public ClientesController(ExerciseContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetCliente()
        {
            return await _context.Persona.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetCliente(int id)
        {
            var cliente = await _context.Persona.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Persona cliente)
        {
            if (id != cliente.ID_PERSONA)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            try
            {
                _context.Persona.Add(cliente);
                await _context.SaveChangesAsync();

                Clientes c = new Clientes();
                c.CONTRASEÑA = cliente.CONTRASEÑA;
                c.ESTADO = cliente.ESTADO;
                c.ID_PERSONA = cliente.ID_PERSONA;

                _context.Clientes.Add(c);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
            }
           

            return CreatedAtAction("GetCliente", new { id = cliente.ID_PERSONA }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Persona.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Persona.Any(e => e.ID_PERSONA == id);
        }
    }
}
