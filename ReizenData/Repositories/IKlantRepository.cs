
using ReizenData.Models;

namespace ReizenData.Repositories;
public interface IKlantRepository
{
    public Task<IEnumerable<Klant>> GetAllKlantenAsync();
    public Task<IEnumerable<Klant>> GetAllKlantenContainingStringAsync(string input);
    public Task<Klant?> GetKlantByIdAsync(int id);
}
