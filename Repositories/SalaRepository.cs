using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly IDataContext _context;
        public SalaRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Sala sala)
        {        
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string sid)
        {
            var itemToRemove = await _context.Salas.FindAsync(sid);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Salas.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Sala> Get(string sid)
        {
            return await _context.Salas.FindAsync(sid);
        }
    
        public async Task<IEnumerable<Sala>> GetAll()
        {
            return await _context.Salas.ToListAsync();
        }
    
        public async Task Update(Sala sala)
        {
            var itemToUpdate = await _context.Salas.FindAsync(sala.sid);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.cantidad_columnas = sala.cantidad_columnas;
            itemToUpdate.cantidad_filas = sala.cantidad_filas;
            await _context.SaveChangesAsync();
    
        }
    }
}