using AdministracionEmpleadosApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpleadosApi.Controllers
{
    [ApiController]
    [Route("api/beneficiarios")]
    public class BeneficiariosController : ControllerBase
    {
        private readonly AplicationDbContext context;
        public BeneficiariosController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Beneficiario>> Get(int id)
        {
            return await context.Beneficiarios.Include(x => x.Empleado).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Beneficiario beneficiario)
        {
            var existeEmpleado = await context.Empleados.AnyAsync(x => x.Id == beneficiario.EmpleadoId);

            if (!existeEmpleado)
            {
                return BadRequest($"No existe el Empleado Id: {beneficiario.EmpleadoId}");
            }

            context.Add(beneficiario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Beneficiario beneficiario, int id)
        {
            var existe = await context.Beneficiarios.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            if (beneficiario.Id != id)
            {
                return BadRequest("El Id del beneficiario no es correcto");
            }
            context.Update(beneficiario);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
