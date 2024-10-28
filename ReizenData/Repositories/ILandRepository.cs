
using ReizenData.Models;

namespace ReizenData.Repositories;
public interface ILandRepository
{
    public Task<IEnumerable<Land>> GetAllLandenAsync();
    public Task<IEnumerable<Land>> GetLandenWithWereldeelIdAsync(int id);
}
