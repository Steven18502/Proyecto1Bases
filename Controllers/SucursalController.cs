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
    [Route("api/Sucursales")]

    public class SucursalController: ControllerBase
    {
        private readonly ISucursalRepository _sucursalRepository;
        public SucursalController(ISucursalRepository sucursalRepository)
        {
        _sucursalRepository = sucursalRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            var sucursals = await _sucursalRepository.GetAll();
            return Ok(sucursals);
        }
    
        [HttpGet("api/{nombre_cine}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(string nombre_cine)
        {
            var sucursal = await _sucursalRepository.Get(nombre_cine);
            if(sucursal == null)
                return NotFound();
    
            return Ok(sucursal);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreateSucursal(CreateSucursalDto createSucursalDto)
        {
            Sucursal sucursal = new()
            {
                nombre_cine = createSucursalDto.nombre_cine,
                ubicacion = createSucursalDto.ubicacion,
                cantidad_salas = createSucursalDto.cantidad_salas
            };
    
            await _sucursalRepository.Add(sucursal);
            return Ok();
        }
    
        [HttpDelete("api/{nombre_cine}")]
        public async Task<ActionResult> DeleteSucursal(string nombre_cine)
        {
            await _sucursalRepository.Delete(nombre_cine);
            return Ok();
        }
    
        [HttpPut("api/{nombre_cine}")]
        public async Task<ActionResult> UpdateSucursal(string nombre_cine, UpdateSucursalDto updateSucursalDto)
        {
            Sucursal sucursal = new()
            {
                ubicacion = updateSucursalDto.ubicacion,
                cantidad_salas = updateSucursalDto.cantidad_salas
            };
            
    
            await _sucursalRepository.Update(sucursal);
            return Ok();
    
        }
    }
}