
using ReizenData.Models;
using ReizenData.Repositories;

namespace ReizenServices;
public class BestemmingService
{
    private IBestemmingRepository repository;
    public BestemmingService(IBestemmingRepository repository)
    {
        this.repository = repository;
    }
    public async Task<IEnumerable<Bestemming>> GetAllBestemmingenByLandIdAsync(int id) => await repository.GetAllBestemmingenByLandIdAsync(id);
}
