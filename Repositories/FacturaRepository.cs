using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IDataContext _context;
        public FacturaRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Factura factura)
        {        
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int facturaId)
        {
            var itemToRemove = await _context.Facturas.FindAsync(facturaId);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Facturas.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Factura> Get(int facturaId)
        {
            return await _context.Facturas.FindAsync(facturaId);
        }
    
        public async Task<IEnumerable<Factura>> GetAll()
        {
            return await _context.Facturas.ToListAsync();
        }
    
        public async Task Update(Factura factura)
        {
            var itemToUpdate = await _context.Facturas.FindAsync(factura.facturaId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Cliente = factura.Cliente;
            itemToUpdate.Sucursal = factura.Sucursal;
            itemToUpdate.Pelicula = factura.Pelicula;
            itemToUpdate.Proyeccion = factura.Proyeccion;
            itemToUpdate.Sala = factura.Sala;
            itemToUpdate.Asiento = factura.Asiento;
            await _context.SaveChangesAsync();
    
        }
    }
}