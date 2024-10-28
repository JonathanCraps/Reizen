using Microsoft.EntityFrameworkCore;
using ReizenData.Models;

namespace ReizenData.Repositories;
public class SQLWerelddeelRepository : IWerelddeelRepository
{
    private readonly ReizenContext context;
    public SQLWerelddeelRepository(ReizenContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Wereldeel>> GetAllWerelddelenAsync() => await context.Werelddelen.OrderBy(wereldeel => wereldeel.Naam).ToListAsync();

    public async Task<Wereldeel?> GetWerelddeelByIdAsync(int id) => await context.Werelddelen.Where(werelddeel => werelddeel.Id == id).SingleOrDefaultAsync();
}
