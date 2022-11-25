using AdministracionEmpleadosApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpleadosApi.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadosController : ControllerBase
    {

        private readonly AplicationDbContext context;

        public EmpleadosController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> Get()
        {
            return await context.Empleados.Include(x => x.Beneficiarios).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var empleados = await context.Empleados.Include(x => x.Beneficiarios).ToListAsync();

            var empleado = empleados.Find(x => x.Id == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(empleado);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Empleado empleado)
        {
            context.Add(empleado);
            await context.SaveChangesAsync();
            return Ok(empleado.Id);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(Empleado empleado, int Id)
        {
            var existe = await context.Empleados.AnyAsync(x => x.Id == Id);

            if (!existe)
            {
                return NotFound();
            }

            if (empleado.Id != Id)
            {
                return BadRequest("El Id del empleado no es correcto");
            }
            context.Update(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Empleados.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Empleado() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
