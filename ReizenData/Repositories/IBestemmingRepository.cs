
using ReizenData.Models;

namespace ReizenData.Repositories;
public interface IBestemmingRepository
{
    public Task<IEnumerable<Bestemming>> GetAllBestemmingenByLandIdAsync(int id);
    public Task<Bestemming?> GetBestemmingByCodeAsync(string code);
}
