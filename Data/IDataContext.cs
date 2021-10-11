using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Models;

// Represents a session with the database and can be used to query and save instances of your entities.

namespace Proyecto1Bases.Data
{
    public interface IDataContext
    {
        DbSet<Pelicula> Peliculas { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}