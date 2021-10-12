using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> Get(string ccedula);
        Task<IEnumerable<Cliente>> GetAll();
        Task Add(Cliente cliente);
        Task Delete(string ccedula);
        Task Update(Cliente cliente);           
    }
}