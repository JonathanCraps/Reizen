using ReizenData.Models;
using ReizenData.Repositories;
namespace ReizenServices;
public class ReisService
{
    private IReisRepository repository;
    public ReisService(IReisRepository repository)
    {
        this.repository = repository;
    }
    public async Task<IEnumerable<Reis>> GetReizenByBestemmingCode(string code) => await repository.GetReizenByBestemmingCodeAsync(code);
    public async Task<Reis?> GetReisByIdAsync(int id) => await repository.GetReisByIdAsync(id);
}
