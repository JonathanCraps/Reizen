using Microsoft.EntityFrameworkCore;
using ReizenData.Models;

namespace ReizenData.Repositories;
public class SQLLandRepository : ILandRepository
{
    private readonly ReizenContext context;
    public SQLLandRepository(ReizenContext context)
    {
       this.context = context;
    }
    public async Task<IEnumerable<Land>> GetAllLandenAsync() => await context.Landen.OrderBy(land => land.Naam).ToListAsync();
    public async Task<IEnumerable<Land>> GetLandenWithWereldeelIdAsync(int id) => await context.Landen.Where(land => land.Werelddeelid == id).OrderBy(land => land.Naam).ToListAsync();

    public async Task<Land?> GetLandWithIdAsync(int id) => await context.Landen.Where(land => land.Id == id).SingleOrDefaultAsync();
    
}
