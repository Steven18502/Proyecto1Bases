using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface IPeliculaRepository
    {
        Task<Pelicula> Get(string pnombre_original);
        Task<IEnumerable<Pelicula>> GetAll();
        Task Add(Pelicula pelicula);
        Task Delete(string pnombre_original);
        Task Update(Pelicula pelicula);         
    }
}

