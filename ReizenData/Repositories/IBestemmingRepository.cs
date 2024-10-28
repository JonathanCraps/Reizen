
using ReizenData.Models;

namespace ReizenData.Repositories;
public interface IBestemmingRepository
{
    public Task<IEnumerable<Bestemming>> GetAllBestemmingenByLandIdAsync(int id);
}
