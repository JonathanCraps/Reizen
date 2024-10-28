using ReizenData.Models;
using ReizenData.Repositories;

namespace ReizenServices;
public class WerelddeelService
{
    private IWerelddeelRepository werelddeelRepository;
    public WerelddeelService(IWerelddeelRepository wereldeelRepository)
    {
        this.werelddeelRepository = wereldeelRepository;
    }
    public async Task<IEnumerable<Wereldeel>> GetAllWerelddelenAsync() => await werelddeelRepository.GetAllWerelddelenAsync();
    public async Task<Wereldeel?> GetWerelddeelByIdAsync(int id) => await werelddeelRepository.GetWerelddeelByIdAsync(id);
}
