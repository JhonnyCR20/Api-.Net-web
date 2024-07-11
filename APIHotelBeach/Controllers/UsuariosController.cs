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
    [Route("api/Usuarios")]
    [EnableCors("ReglasCors")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly APIcontexto _context;

        public UsuariosController(APIcontexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return this._context.Usuarios.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("Buscar/{Email}")]
        public IActionResult Get(string? Email)
        {
            var temp = _context.Usuarios.FirstOrDefault(u => u.Email.Equals(Email));


            if (temp == null)
            {
                return BadRequest("Usuario no encontrado");
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

        // PUT api/<UsuarioController>/5
        [HttpPut("agregar")]
        public IActionResult Put([FromBody] Usuarios user)
        {
            try
            {
                this._context.Usuarios.Add(user);
                this._context.SaveChanges();
                return Ok("El Usuario se agrego correctamente");

            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }


        [HttpPut("EditarPassword/{Email}")]
        public IActionResult Edit([FromBody] Usuarios usuarios, string Email)
        {
            var temp = _context.Usuarios.FirstOrDefault(u => u.Email.Equals(Email)); ;

            if (temp == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
            {

                temp.Password = usuarios.Password;
                temp.Restablecer = 1;

                this._context.Usuarios.Update(temp);
                this._context.SaveChanges();

                return Ok("El usuario se edito correctamente");
            }
            catch (Exception ex)
            {

                return NotFound("Error " + ex.Message);
            }


        }


    }
}
