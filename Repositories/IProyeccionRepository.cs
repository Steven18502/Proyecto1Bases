using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface IProyeccionRepository
    {
        Task<Proyeccion> Get(int proyeccionId);
        Task<IEnumerable<Proyeccion>> GetAll();
        Task Add(Proyeccion proyeccion);
        Task Delete(int proyeccionId);
        Task Update(Proyeccion proyeccion); 
    }
}