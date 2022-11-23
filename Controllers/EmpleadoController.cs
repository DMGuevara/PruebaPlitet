using Microsoft.AspNetCore.Mvc;
using RestDemo.Data;
using RestDemo.Models;

namespace RestDemo.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<EmpleadoInfo>>> Get()
        {
            var funtion = new DataEmpleados();
            var lista = await funtion.Mostrarempleados();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] EmpleadoInfo parametros)
        {
            var funtion = new DataEmpleados();
            await funtion.Insertarempleados(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmpleadoInfo parametros)
        {
            var funtion = new DataEmpleados();
            parametros.empleado_id = id;
            await funtion.Editarempleados(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funtion = new DataEmpleados();
            var parametros = new EmpleadoInfo();
            parametros.empleado_id = id;
            await funtion.Eliminarempleados(parametros);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> consultarCliente(int id)
        {
            var funtion = new DataEmpleados();
            var parametros = new EmpleadoInfo();
            parametros.empleado_id = id;
            await funtion.Consultarempleados(parametros);
            return NoContent();
        }
    }
}
