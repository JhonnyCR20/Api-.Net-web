using System;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIHotelBeach.Models;

namespace APIHotelBeach.Controllers
{
    [Route("api/Clientes")]
    [EnableCors("ReglasCors")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly APIcontexto _context;

        public ClientesController(APIcontexto context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet("ListaClientes")]
        public IEnumerable<Cliente> Get()
        {
            return this._context.Cliente.ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var temp = _context.Cliente.Find(id); ;

            if (temp == null)
            {
                return BadRequest("Cliente no encontrado");
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

        [HttpGet("BuscarCedula/{Cedula}")]
        public IActionResult BuscarCedula(string cedula)
        {
            var temp = _context.Cliente.FirstOrDefault(u => u.Cedula.Equals(cedula));

            if (temp == null)
            {
                return BadRequest("No existe un cliente con esa cedula");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK,  temp );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, temp );
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("agregar")]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                this._context.Cliente.Add(cliente);
                this._context.SaveChanges();
                return Ok("El Cliente se reservo correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var temp = this._context.Cliente.Find(id);
            if (temp == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                this._context.Cliente.Remove(temp);
                this._context.SaveChanges();
                return Ok("Se elimino correctamente el cliente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        //Metodo editar
        [HttpPut("Editar/{id}")]
        public IActionResult Edit([FromBody] Cliente cliente, int id)
        {
            var temp = this._context.Cliente.Find(id);
            if (temp == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                temp.TipoCedula = cliente.TipoCedula;
                temp.Cedula = cliente.Cedula;
                temp.NombreCompleto = cliente.NombreCompleto;
                temp.Telefono = cliente.Telefono;
                temp.Direccion = cliente.Direccion;
                temp.CorreoElectronico = cliente.CorreoElectronico;

                this._context.Cliente.Update(temp);
                this._context.SaveChanges();
                return Ok("El cliente se edito correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
    }
}
