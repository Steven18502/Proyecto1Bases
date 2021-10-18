using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class ProyeccionRepository : IProyeccionRepository
    {
        private readonly IDataContext _context;
        public ProyeccionRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Proyeccion proyeccion)
        {        
            _context.Proyecciones.Add(proyeccion);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int proyeccionId)
        {
            var itemToRemove = await _context.Proyecciones.FindAsync(proyeccionId);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Proyecciones.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Proyeccion> Get(int proyeccionId)
        {
            return await _context.Proyecciones.FindAsync(proyeccionId);
        }
    
        public async Task<IEnumerable<Proyeccion>> GetAll()
        {
            return await _context.Proyecciones.ToListAsync();
        }
    
        public async Task Update(Proyeccion proyeccion)
        {
            var itemToUpdate = await _context.Proyecciones.FindAsync(proyeccion.proyeccionId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.horario = proyeccion.horario;
            itemToUpdate.cine = proyeccion.cine;
            await _context.SaveChangesAsync();
    
        }
    }
}