using AgendaUsuarios.DAL.DataContext;
using AgendaUsuarios.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaUsuarios.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Usuarios
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
