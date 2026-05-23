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

        public ContactoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader(Name = "x-api-key")] string apiKey)
        {
            if (apiKey != "123456")
            {
                return Unauthorized("API Key inválida");
            }

            var lista = await _context.Contactos.ToListAsync();

            return Ok(lista);
        }
    }
}