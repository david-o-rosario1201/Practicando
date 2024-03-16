using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Practicando.API.DAL;
using NuGet.Protocol;
using System.Runtime.InteropServices;

namespace Practicando.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuariosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.Include(u => u.UsuariosDetalles).ToListAsync();
        }

		// GET: api/Usuarios
		[HttpGet("Telefonos")]
		public async Task<ActionResult<IEnumerable<TiposTelefonos>>> GetTelefonos()
		{
			return await _context.TiposTelefonos.ToListAsync();
		}

		// GET: api/Usuarios/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
          if(_context.Usuarios == null)
           {
                return NotFound();
           }

          var usuarios = await _context.Usuarios
                .Include(u => u.UsuariosDetalles)
                .Where(u => u.UsuarioId == id)
                .FirstOrDefaultAsync();

           if(usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

		// PUT: api/Usuarios/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
			//if (id != usuarios.UsuarioId)
			//{
			//    return BadRequest();
			//}

			//_context.Entry(usuarios).State = EntityState.Modified;

			//try
			//{
			//    await _context.SaveChangesAsync();
			//}
			//catch (DbUpdateConcurrencyException)
			//{
			//    if (!UsuariosExists(id))
			//    {
			//        return NotFound();
			//    }
			//    else
			//    {
			//        throw;
			//    }
			//}

			//return NoContent();

			if (!UsuariosExists(id))
				_context.Usuarios.Add(usuarios);
			else
				_context.Usuarios.Update(usuarios);

			_context.SaveChanges();

			return Ok(usuarios);
		}

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            if (!UsuariosExists(usuarios.UsuarioId))
                _context.Usuarios.Add(usuarios);
            else
                _context.Usuarios.Update(usuarios);

            _context.SaveChanges();

            return Ok(usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

		// DELETE: api/Usuarios/5/Detalle/2
		[HttpDelete("{usuarioId}/Detalle/{detalleId}")]
		public async Task<IActionResult> DeleteUsuarios(int usuarioId, int detalleId)
		{
			var usuarios = await _context.Usuarios.Include(u => u.UsuariosDetalles).FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
			if (usuarios == null)
			{
				return NotFound();
			}

            var detalle = usuarios.UsuariosDetalles.FirstOrDefault(d => d.DetalleId == detalleId);

            if(detalle == null)
            {
                return NotFound();
            }

            usuarios.UsuariosDetalles.Remove(detalle);

			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
