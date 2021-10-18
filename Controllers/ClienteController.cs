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
    [Route("api/Clientes")]

    public class ClienteController: ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
        _clienteRepository = clienteRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAll();
            return Ok(clientes);
        }
    
        [HttpGet("{ccedula}")]
        public async Task<ActionResult<Cliente>> GetCliente(string ccedula)
        {
            var cliente = await _clienteRepository.Get(ccedula);
            if(cliente == null)
                return NotFound();
    
            return Ok(cliente);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
        {
            Cliente cliente = new()
            {
                ccedula = createClienteDto.ccedula,
                cusuario = createClienteDto.cusuario,
                cconstrasenia = createClienteDto.cconstrasenia,
                cnombre_completo = createClienteDto.cnombre_completo,
                cedad = createClienteDto.cedad,
                cfecha_nacimiento = createClienteDto.cfecha_nacimiento,
                ctelefono = createClienteDto.ctelefono
            };
    
            await _clienteRepository.Add(cliente);
            return Ok();
        }
    
        [HttpDelete("{ccedula}")]
        public async Task<ActionResult> DeleteCliente(string ccedula)
        {
            await _clienteRepository.Delete(ccedula);
            return Ok();
        }
    
        [HttpPut("{ccedula}")]
        public async Task<ActionResult> UpdateCliente(string ccedula, UpdateClienteDto updateClienteDto)
        {
            Cliente cliente = new()
            {
                cusuario = updateClienteDto.cusuario,
                cconstrasenia = updateClienteDto.cconstrasenia,
                cnombre_completo = updateClienteDto.cnombre_completo,
                cedad = updateClienteDto.cedad,
                cfecha_nacimiento = updateClienteDto.cfecha_nacimiento,
                ctelefono = updateClienteDto.ctelefono
            };
            
    
            await _clienteRepository.Update(cliente);
            return Ok();
    
        }

        
    }
}