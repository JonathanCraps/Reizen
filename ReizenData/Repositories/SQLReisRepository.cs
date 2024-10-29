using Microsoft.EntityFrameworkCore;
using ReizenData.Models;

namespace ReizenData.Repositories;
public class SQLReisRepository : IReisRepository
{
    private readonly ReizenContext context;
    public SQLReisRepository(ReizenContext context)
    {
        this.context = context;
    }

    public async Task<Reis?> GetReisByIdAsync(int id) => 
         await context.Reizen.Where(reis => reis.Id == id).SingleOrDefaultAsync();
    

    public async Task<IEnumerable<Reis>> GetReizenByBestemmingCodeAsync(string code) => await context.Reizen.Where(reis => reis.Bestemmingscode == code).OrderBy(reis => reis.Vertrek).ToListAsync();
}
