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
    [Route("api/Salas")]

    public class SalaController: ControllerBase
    {
        private readonly ISalaRepository _salaRepository;
        public SalaController(ISalaRepository salaRepository)
        {
        _salaRepository = salaRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas()
        {
            var salas = await _salaRepository.GetAll();
            return Ok(salas);
        }
    
        [HttpGet("{sid}")]
        public async Task<ActionResult<Sala>> GetSala(string sid)
        {
            var sala = await _salaRepository.Get(sid);
            if(sala == null)
                return NotFound();
    
            return Ok(sala);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreateSala(CreateSalaDto createSalaDto)
        {
            Sala sala = new()
            {
                sid = createSalaDto.sid,
                nombre_sucursal = createSalaDto.nombre_sucursal,
                cantidad_columnas = createSalaDto.cantidad_columnas,
                cantidad_filas = createSalaDto.cantidad_filas,
                scapacidad = createSalaDto.scapacidad
            };
    
            await _salaRepository.Add(sala);
            return Ok();
        }
    
        [HttpDelete("{sid}")]
        public async Task<ActionResult> DeleteSala(string sid)
        {
            await _salaRepository.Delete(sid);
            return Ok();
        }
    
        [HttpPut("{sid}")]
        public async Task<ActionResult> UpdateSala(string sid, UpdateSalaDto updateSalaDto)
        {
            Sala sala = new()
            {
                nombre_sucursal = updateSalaDto.nombre_sucursal,
                cantidad_columnas = updateSalaDto.cantidad_columnas,
                cantidad_filas = updateSalaDto.cantidad_filas,
                scapacidad = updateSalaDto.scapacidad
            };
            
    
            await _salaRepository.Update(sala);
            return Ok();
    
        }
    }
}