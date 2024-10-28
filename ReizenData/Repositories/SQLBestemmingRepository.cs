using Microsoft.EntityFrameworkCore;
using ReizenData.Models;

namespace ReizenData.Repositories;
public class SQLBestemmingRepository : IBestemmingRepository
{
    private readonly ReizenContext context;
    public SQLBestemmingRepository(ReizenContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Bestemming>> GetAllBestemmingenByLandIdAsync(int id) => await context.Bestemmingen.Where(bestemming => bestemming.Landid == id).ToListAsync();
}
