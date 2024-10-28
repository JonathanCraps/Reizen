using ReizenData.Models;
using ReizenData.Repositories;

namespace ReizenServices;
public class LandService
{
    private ILandRepository landRepository;
    public LandService(ILandRepository landRepository)
    {
        this.landRepository = landRepository;
    }
    public async Task<IEnumerable<Land>> GetAllLandenAsync() => await landRepository.GetAllLandenAsync();
    public async Task<IEnumerable<Land>> GetLandenWithWereldeelIdAsync(int id) => await landRepository.GetLandenWithWereldeelIdAsync(id);
    public async Task<Land?> GetLandWithIdAsync(int id) => await landRepository.GetLandWithIdAsync(id);
}
