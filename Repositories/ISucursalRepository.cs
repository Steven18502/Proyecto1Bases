using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface ISucursalRepository
    {
        Task<Sucursal> Get(string nombre_cine);
        Task<IEnumerable<Sucursal>> GetAll();
        Task Add(Sucursal sucursal);
        Task Delete(string nombre_cine);
        Task Update(Sucursal sucursal); 
    }
}