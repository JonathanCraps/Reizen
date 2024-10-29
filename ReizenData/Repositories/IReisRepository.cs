using ReizenData.Models;
namespace ReizenData.Repositories;
public interface IReisRepository
{
    public Task<IEnumerable<Reis>> GetReizenByBestemmingCodeAsync(string code);
    public Task<Reis?> GetReisByIdAsync(int id);
}
