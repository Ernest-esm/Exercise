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
    public class MovimientosController : ControllerBase
    {
        private readonly ExerciseContext _context;
        private IQueryable<MovReturn> movimientos;

        public MovimientosController(ExerciseContext context)
        {
            _context = context;
        }

        // GET: api/Movimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimientos>>> GetMovimientos()
        {
            return await _context.Movimientos.ToListAsync();
        }

        // GET: api/Movimientos/5
        [HttpGet("{Parametro}")]
        public async Task<ActionResult<IEnumerable<MovReturn>>> GetMovimientos(string Parametro)
        {
           //por nombre
            movimientos = from p in _context.Persona
                              join c in _context.Clientes on p.ID_PERSONA equals c.ID_PERSONA
                              join m in _context.Movimientos on c.ID_CLIENTE equals m.ID_CLIENTE
                              join cu in _context.Cuenta on m.ID_CUENTA equals cu.ID_CUENTA
                              where p.NOMBRE.Equals(Parametro)
                              select new MovReturn()
                              {
                                  ESTADO = m.ESTADO.ToString(),
                                  FECHA = m.FECHA.ToString(),
                                  CLIENTE = p.NOMBRE,
                                  MOVIMIENTO = m.MOVIMIENTO,
                                  NUMERO_CUENTA = cu.NUMERO_CUENTA,
                                  SALDO_DISPONIBLE = m.SALDO,
                                  SALDO_INICIAL = cu.SALDO_INI,
                                  TIPO_CUENTA = cu.TIPO_CUENTA
                                  
                              };
            movimientos.ToList();
            List<MovReturn> List = new List<MovReturn>();
            if (movimientos.Count() > 0)
            {
                foreach (var item in movimientos)
                {
                    MovReturn mov = new MovReturn();
                    mov.FECHA = item.FECHA;
                    mov.CLIENTE = item.CLIENTE;
                    mov.NUMERO_CUENTA = item.NUMERO_CUENTA;
                    mov.TIPO_CUENTA = item.TIPO_CUENTA;
                    mov.SALDO_INICIAL = item.SALDO_INICIAL;
                    mov.MOVIMIENTO = item.MOVIMIENTO;
                    mov.SALDO_DISPONIBLE = item.SALDO_DISPONIBLE;
                    mov.ESTADO = item.ESTADO;
                    List.Add(mov);
                }
            }
            else
            {
                //por fecha
                var fechaDT = DateTime.Parse(Parametro);
                movimientos = from m in _context.Movimientos 
                              join c in _context.Clientes on m.ID_CLIENTE equals c.ID_CLIENTE
                              join cu in _context.Cuenta on m.ID_CUENTA equals cu.ID_CUENTA
                              join p in _context.Persona on c.ID_PERSONA equals p.ID_PERSONA 
                                  where m.FECHA >= fechaDT
                                  select new MovReturn()
                                  {
                                      ESTADO = m.ESTADO.ToString(),
                                      FECHA = m.FECHA.ToString(),
                                      CLIENTE = p.NOMBRE,
                                      MOVIMIENTO = m.MOVIMIENTO,
                                      NUMERO_CUENTA = cu.NUMERO_CUENTA,
                                      SALDO_DISPONIBLE = m.SALDO,
                                      SALDO_INICIAL = cu.SALDO_INI,
                                      TIPO_CUENTA = cu.TIPO_CUENTA

                                  };
                movimientos.ToList();
                foreach (var item in movimientos)
                {
                    MovReturn mov = new MovReturn();
                    mov.FECHA = item.FECHA;
                    mov.CLIENTE = item.CLIENTE;
                    mov.NUMERO_CUENTA = item.NUMERO_CUENTA;
                    mov.TIPO_CUENTA = item.TIPO_CUENTA;
                    mov.SALDO_INICIAL = item.SALDO_INICIAL;
                    mov.MOVIMIENTO = item.MOVIMIENTO;
                    mov.SALDO_DISPONIBLE = item.SALDO_DISPONIBLE;
                    mov.ESTADO = item.ESTADO;
                    List.Add(mov);
                }
            }
          
            
           
            if (movimientos == null)
            {
                return NotFound();
            }

            return List;
        }

        // PUT: api/Movimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientos(int id, Movimientos movimientos)
        {
            if (id != movimientos.ID_MOV)
            {
                return BadRequest();
            }

            _context.Entry(movimientos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientosExists(id))
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

        // POST: api/Movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movimientos>> PostMovimientos(Movimientos movimientos)
        {
            try
            {
                movimientos.FECHA = DateTime.Now;
                var saldo_ini = _context.Cuenta.Where(q => q.ID_CLIENTE == movimientos.ID_CLIENTE && q.ID_CUENTA == movimientos.ID_CUENTA).FirstOrDefault().SALDO_INI;
                var saldo = _context.Movimientos.Where(q => q.ID_CLIENTE == movimientos.ID_CLIENTE && q.ID_CUENTA == movimientos.ID_CUENTA).OrderBy(q => q.FECHA).LastOrDefault().SALDO;
                if (movimientos.MOVIMIENTO < 0 && saldo == 0)
                {
                    
                    return CreatedAtAction("GetMsg", new { id = 1 });
                }
                else
                {
                    movimientos.SALDO = saldo_ini + (movimientos.MOVIMIENTO);
                    _context.Movimientos.Add(movimientos);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {


            }



            return CreatedAtAction("GetMovimientos", new { id = movimientos.ID_MOV }, movimientos);
        }

        // DELETE: api/Movimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientos(int id)
        {
            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }

            _context.Movimientos.Remove(movimientos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientosExists(int id)
        {
            return _context.Movimientos.Any(e => e.ID_MOV == id);
        }

        /*
        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensajes>> GetMsg(int id)
        {
            var movimientos = await _context.Mensajes.FindAsync(id);

            if (movimientos == null)
            {
                return NotFound();
            }

            return movimientos;
        }
        */
    }
}
