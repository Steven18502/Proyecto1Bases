using Microsoft.EntityFrameworkCore;
using Proyecto1Bases.Models;
using System.Threading.Tasks;

// Use PeliculaRepository to query and save data to our database.

namespace Proyecto1Bases.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }
 
        public DbSet<Pelicula> Peliculas { get; init; }
    }
}
