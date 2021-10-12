using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IDataContext _context;
        public EmpleadoRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Empleado empleado)
        {        
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string ecedula)
        {
            var itemToRemove = await _context.Empleados.FindAsync(ecedula);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Empleados.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Empleado> Get(string ecedula)
        {
            return await _context.Empleados.FindAsync(ecedula);
        }
    
        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _context.Empleados.ToListAsync();
        }
    
        public async Task Update(Empleado empleado)
        {
            var itemToUpdate = await _context.Empleados.FindAsync(empleado.ecedula);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.eusuario = empleado.eusuario;
            itemToUpdate.econstrasenia = empleado.econstrasenia ;
            await _context.SaveChangesAsync();
    
        }
    }
}