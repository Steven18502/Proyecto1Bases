using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface IEmpleadoRepository
    {
         Task<Empleado> Get(string ecedula);
        Task<IEnumerable<Empleado>> GetAll();
        Task Add(Empleado empleado);
        Task Delete(string ecedula);
        Task Update(Empleado empleado);   
    }
}