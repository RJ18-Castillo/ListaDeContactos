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

        private const string API_KEY = "123456";

        public ContactoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!Request.Headers.TryGetValue("x-api-key", out var apiKey))
            {
                return Unauthorized("API Key requerida");
            }

            if (apiKey != API_KEY)
            {
                return Unauthorized("API Key inválida");
            }

            var lista = await _context.Contactos.ToListAsync();

            return Ok(lista);
        }
    }
}