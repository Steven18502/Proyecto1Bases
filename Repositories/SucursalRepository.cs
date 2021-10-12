using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly IDataContext _context;
        public SucursalRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Sucursal sucursal)
        {        
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string nombre_cine)
        {
            var itemToRemove = await _context.Sucursales.FindAsync(nombre_cine);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Sucursales.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Sucursal> Get(string nombre_cine)
        {
            return await _context.Sucursales.FindAsync(nombre_cine);
        }
    
        public async Task<IEnumerable<Sucursal>> GetAll()
        {
            return await _context.Sucursales.ToListAsync();
        }
    
        public async Task Update(Sucursal sucursal)
        {
            var itemToUpdate = await _context.Sucursales.FindAsync(sucursal.nombre_cine);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.ubicacion = sucursal.ubicacion;
            itemToUpdate.cantidad_salas = sucursal.cantidad_salas;
            await _context.SaveChangesAsync();
    
        }
    }
}