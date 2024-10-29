
using Microsoft.EntityFrameworkCore;
using ReizenData.Models;

namespace ReizenData.Repositories;
public class SQLKlantRepository : IKlantRepository
{
    private ReizenContext context;
    public SQLKlantRepository(ReizenContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Klant>> GetAllKlantenAsync()
    {
        return await context.Klanten.OrderBy(klant => klant.Familienaam).ThenBy(klant => klant.Voornaam).ToListAsync();
    }

    public async Task<IEnumerable<Klant>> GetAllKlantenContainingStringAsync(string input)
    {
        return await context.Klanten
            .Where(klant => klant.Familienaam.ToLower()
            .Contains(input.ToLower()))
            .OrderBy(klant => klant.Familienaam)
            .ThenBy(klant => klant.Voornaam)
            .ToListAsync();
            
    }

    public async Task<Klant?> GetKlantByIdAsync(int id)
    {
        return await context.Klanten.Where(klant => klant.Id == id).SingleOrDefaultAsync();
    }
}
