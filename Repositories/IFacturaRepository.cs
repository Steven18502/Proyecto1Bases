using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Models;
using Microsoft.Extensions.Configuration;

namespace Proyecto1Bases.Repositories
{
    public interface IFacturaRepository
    {
        Task<Factura> Get(int facturaId);
        Task<IEnumerable<Factura>> GetAll();
        Task Add(Factura factura);
        Task Delete(int facturaId);
        Task Update(Factura factura);           
    }
}