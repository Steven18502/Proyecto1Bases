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
    [Route("api/Proyecciones")]

    public class ProyeccionController: ControllerBase
    {
        private readonly IProyeccionRepository _proyeccionRepository;
        public ProyeccionController(IProyeccionRepository proyeccionRepository)
        {
        _proyeccionRepository = proyeccionRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyeccion>>> GetProyecciones()
        {
            var proyecciones = await _proyeccionRepository.GetAll();
            return Ok(proyecciones);
        }
    
        [HttpGet("{proyeccionid}")]
        public async Task<ActionResult<Proyeccion>> GetProyeccion(int proyeccionid)
        {
            var proyeccion = await _proyeccionRepository.Get(proyeccionid);
            if(proyeccion == null)
                return NotFound();
    
            return Ok(proyeccion);
        }

    
        [HttpPost]
        public async Task<ActionResult> CreateProyeccion(CreateProyeccionDto createProyeccionDto)
        {
            Proyeccion proyeccion = new()
            {
                //proyeccionid = createProyeccionDto.proyeccionid,
                horario = createProyeccionDto.horario,
                cine = createProyeccionDto.cine,
                sala = createProyeccionDto.sala
            };
    
            await _proyeccionRepository.Add(proyeccion);
            return Ok();
        }
    
        [HttpDelete("{proyeccionid}")]
        public async Task<ActionResult> DeleteProyeccion(int proyeccionid)
        {
            await _proyeccionRepository.Delete(proyeccionid);
            return Ok();
        }
    
        [HttpPut("{proyeccionid}")]
        public async Task<ActionResult> UpdateProyeccion(int proyeccionid, UpdateProyeccionDto updateProyeccionDto)
        {
            Proyeccion proyeccion = new()
            {
                horario = updateProyeccionDto.horario,
                cine = updateProyeccionDto.cine,
                sala = updateProyeccionDto.sala,
            };
            
    
            await _proyeccionRepository.Update(proyeccion);
            return Ok();
    
        }
    }
}