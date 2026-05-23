using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaDeContactos.Api.Data;
using ListaDeContactos.Api.Models;

namespace ListaDeContactos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactoController(
            AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> Get()
        {
            return await _context.Contactos.ToListAsync();
        }
    }
}