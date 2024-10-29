
using ReizenData.Models;
using ReizenData.Repositories;

namespace ReizenServices;
public class KlantService
{
    private IKlantRepository klantRepository;
    public KlantService(IKlantRepository klantRepository)
    {
        this.klantRepository = klantRepository;
    }
    public async Task<IEnumerable<Klant>> GetAllKlantenAsync() => await klantRepository.GetAllKlantenAsync();
    public async Task<IEnumerable<Klant>> GetAllKlantenContainingStringAsync(string input) => await klantRepository.GetAllKlantenContainingStringAsync(input);
    public async Task<Klant?> GetKlantByIdAsync(int id) => await klantRepository.GetKlantByIdAsync(id);
}
