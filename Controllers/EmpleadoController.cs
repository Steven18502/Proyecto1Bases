using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1Bases.Dtos;
using Proyecto1Bases.Models;
using Proyecto1Bases.Repositories;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Controllers
{
    [ApiController]
    [Route("api/Empleados")]

    public class EmpleadoController: ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
        _empleadoRepository = empleadoRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _empleadoRepository.GetAll();
            return Ok(empleados);
        }
    
        [HttpGet("api/{ecedula}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string ecedula)
        {
            var empleado = await _empleadoRepository.Get(ecedula);
            if(empleado == null)
                return NotFound();
    
            return Ok(empleado);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreateEmpleado(CreateEmpleadoDto createEmpleadoDto)
        {
            Empleado empleado = new()
            {
                ecedula = createEmpleadoDto.ecedula,
                eusuario = createEmpleadoDto.eusuario,
                econstrasenia = createEmpleadoDto.econstrasenia,
                enombre_completo = createEmpleadoDto.enombre_completo,
                eedad = createEmpleadoDto.eedad,
                efecha_nacimiento = createEmpleadoDto.efecha_nacimiento,
                etelefono = createEmpleadoDto.etelefono,
                rol = createEmpleadoDto.rol
            };
    
            await _empleadoRepository.Add(empleado);
            return Ok();
        }
    
        [HttpDelete("api/{ecedula}")]
        public async Task<ActionResult> DeleteEmpleado(string ecedula)
        {
            await _empleadoRepository.Delete(ecedula);
            return Ok();
        }
    
        [HttpPut("api/{ecedula}")]
        public async Task<ActionResult> UpdateEmpleado(string ecedula, UpdateEmpleadoDto updateEmpleadoDto)
        {
            Empleado empleado = new()
            {
                eusuario = updateEmpleadoDto.eusuario,
                econstrasenia = updateEmpleadoDto.econstrasenia,
                enombre_completo = updateEmpleadoDto.enombre_completo,
                eedad = updateEmpleadoDto.eedad,
                efecha_nacimiento = updateEmpleadoDto.efecha_nacimiento,
                etelefono = updateEmpleadoDto.etelefono
            };
            
    
            await _empleadoRepository.Update(empleado);
            return Ok();
    
        }
    }
}