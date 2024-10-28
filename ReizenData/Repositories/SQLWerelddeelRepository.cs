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
    public async Task<IEnumerable<Wereldeel>> GetAllWerelddelenAsync() => await context.Werelddelen.ToListAsync();

}
