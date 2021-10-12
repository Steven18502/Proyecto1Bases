using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface ISalaRepository
    {
        Task<Sala> Get(string sid);
        Task<IEnumerable<Sala>> GetAll();
        Task Add(Sala sala);
        Task Delete(string sid);
        Task Update(Sala sala); 
    }
}