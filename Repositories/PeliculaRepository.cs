using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

// Repositorio que se encarga de recibir y enviar los datos a la base de datos

namespace Proyecto1Bases.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly IDataContext _context;
        public PeliculaRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Pelicula pelicula)
        {        
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string pnombre_original)
        {
            var itemToRemove = await _context.Peliculas.FindAsync(pnombre_original);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Peliculas.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Pelicula> Get(string pnombre_original)
        {
            return await _context.Peliculas.FindAsync(pnombre_original);
        }
    
        public async Task<IEnumerable<Pelicula>> GetAll()
        {
            return await _context.Peliculas.ToListAsync();
        }
    
        public async Task Update(Pelicula pelicula)
        {
            var itemToUpdate = await _context.Peliculas.FindAsync(pelicula.pnombre_original);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.pnombre = pelicula.pnombre;
            itemToUpdate.clasificacion = pelicula.clasificacion ;
            await _context.SaveChangesAsync();
    
        }

    }
}