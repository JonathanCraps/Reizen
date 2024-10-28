namespace ReizenData.Repositories;
using ReizenData.Models;
public interface IWerelddeelRepository
{
    public Task<IEnumerable<Wereldeel>> GetAllWerelddelenAsync();
}
