using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIHotelBeach.Models;

namespace APIHotelBeach.Controllers
{
    [Route("api/Reservacion")]
    [EnableCors("ReglasCors")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private readonly APIcontexto _context;

        public ReservacionController(APIcontexto context)
        {
            _context = context;
        }

        // GET: api/<ReservacionController>
        [HttpGet("ListaReservacion")]
        public IEnumerable<Reservacion> Get()
        {
            return this._context.Reservacion.ToList();
        }

        // GET api/<ReservacionController>/5
        [HttpGet("Buscar/{id}")]
        public IActionResult Get(int id)
        {
            var temp = _context.Reservacion.Find(id); ;
            if (temp == null)
            {
                return BadRequest("Reservacion no encontrado");
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, temp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, temp);
            }
        }

        // PUT api/<ReservacionController>/5


        [HttpPut("Agregar")]
        public IActionResult Put([FromBody] Reservacion reserva)
        {
            try
            {
                this._context.Reservacion.Add(reserva);
                this._context.SaveChanges();
                return Ok("La reservacion agrego correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
        // DELETE api/<ReservacionController>/5
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var temp = this._context.Reservacion.Find(id);
            if (temp == null)
            {
                return BadRequest("Reservacion no encontrado");
            }

            try
            {
                this._context.Reservacion.Remove(temp);
                this._context.SaveChanges();
                return Ok("Se elimino correctamente la reservacion");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
    }
}
