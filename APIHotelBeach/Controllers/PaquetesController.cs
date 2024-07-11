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
    [Route("api/Paquetes")]
    [EnableCors("ReglasCors")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly APIcontexto _context;

        public PaquetesController(APIcontexto context)
        {
            _context = context;
        }

        // GET: api/<PaqueteController>
        [HttpGet("ListaPaquetes")]
        public IEnumerable<Paquete> Get()
        {
            return this._context.Paquete.ToList();
        }

        // GET api/<PaqueteController>/5
        [HttpGet("Buscar/{id}")]
        public IActionResult Get(int id)
        {
            var temp = _context.Paquete.Find(id); ;

            if (temp == null)
            {
                return BadRequest("Paquete no encontrado");
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

        [HttpGet("BuscarNombre/{NombrePaquete}")]
        public IActionResult Get(string NombrePaquete)
        {
            var temp = _context.Paquete.FirstOrDefault(u => u.NombrePaquete.Equals(NombrePaquete)); ;

            if (temp == null)
            {
                return BadRequest("Paquete no encontrado");
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




        // PUT api/<PaqueteController>/5
        [HttpPut("Agregar")]
        public IActionResult Put([FromBody] Paquete paquete)
        {
            try
            {
                this._context.Paquete.Add(paquete);
                this._context.SaveChanges();
                return Ok("El Paquete se agrego correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        // DELETE api/<PaqueteController>/5
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var temp = this._context.Paquete.Find(id);
            if (temp == null)
            {
                return BadRequest("Paquete no encontrado");
            }

            try
            {
                this._context.Paquete.Remove(temp);
                this._context.SaveChanges();
                return Ok("Se elimino correctamente el paquete");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        //Metodo editar 
        [HttpPut("Editar/{id}")]
        public IActionResult Edit([FromBody] Paquete paquete, int id)
        {
            var temp = this._context.Paquete.Find(id);
            if (temp == null)
            {
                return BadRequest("Paquete no encontrado");
            }

            try
            {
                temp.NombrePaquete = paquete.NombrePaquete;
                temp.Precio = paquete.Precio;
                temp.ProcentajePrima = paquete.ProcentajePrima;
                temp.NumMensualidades = paquete.NumMensualidades;

                this._context.Paquete.Update(temp);
                this._context.SaveChanges();
                return Ok("El paquete se edito correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
    }
}
