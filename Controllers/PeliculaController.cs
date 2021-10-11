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
    [Route("api/Peliculas")]
    public class PeliculaController: ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        public PeliculaController(IPeliculaRepository peliculaRepository)
        {
        _peliculaRepository = peliculaRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            var peliculas = await _peliculaRepository.GetAll();
            return Ok(peliculas);
        }
    
        [HttpGet("api/{pnombre_original}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(string pnombre_original)
        {
            var pelicula = await _peliculaRepository.Get(pnombre_original);
            if(pelicula == null)
                return NotFound();
    
            return Ok(pelicula);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreatePelicula(CreatePeliculaDto createPeliculaDto)
        {
            Pelicula pelicula = new()
            {
                pnombre_original = createPeliculaDto.pnombre_original,
                pnombre = createPeliculaDto.pnombre,
                pduracion = createPeliculaDto.pduracion,
                director = createPeliculaDto.director,
                clasificacion = createPeliculaDto.clasificacion,
                protagonistas = createPeliculaDto.protagonistas,
                pimagen = createPeliculaDto.pimagen
            };
    
            await _peliculaRepository.Add(pelicula);
            return Ok();
        }
    
        [HttpDelete("api/{pnombre_original}")]
        public async Task<ActionResult> DeletePelicula(string pnombre_original)
        {
            await _peliculaRepository.Delete(pnombre_original);
            return Ok();
        }
    
        [HttpPut("api/{pnombre_original}")]
        public async Task<ActionResult> UpdatePelicula(string pnombre_original, UpdatePeliculaDto updatePeliculaDto)
        {
            Pelicula pelicula = new()
            {
                pnombre = updatePeliculaDto.pnombre,
                pduracion = updatePeliculaDto.pduracion,
                director = updatePeliculaDto.director,
                clasificacion = updatePeliculaDto.clasificacion,
                protagonistas = updatePeliculaDto.protagonistas,
                pimagen = updatePeliculaDto.pimagen
            };
            
    
            await _peliculaRepository.Update(pelicula);
            return Ok();
    
        }
    }
}