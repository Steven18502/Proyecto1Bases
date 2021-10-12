using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Data;
using Proyecto1Bases.Models;

namespace Proyecto1Bases.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDataContext _context;
        public ClienteRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Cliente cliente)
        {        
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string ccedula)
        {
            var itemToRemove = await _context.Clientes.FindAsync(ccedula);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Clientes.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Cliente> Get(string ccedula)
        {
            return await _context.Clientes.FindAsync(ccedula);
        }
    
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
    
        public async Task Update(Cliente cliente)
        {
            var itemToUpdate = await _context.Clientes.FindAsync(cliente.ccedula);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.cusuario = cliente.cusuario;
            itemToUpdate.cconstrasenia = cliente.cconstrasenia ;
            await _context.SaveChangesAsync();
    
        }

    }
}