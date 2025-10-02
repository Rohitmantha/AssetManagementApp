using AssetManagement.Models;

namespace AssetManagement.Business.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task<Asset?> GetAssetByIdAsync(int id);
        Task<Asset> CreateAssetAsync(Asset asset);
        Task UpdateAssetAsync(Asset asset);
        Task DeleteAssetAsync(int id);
        Task<IEnumerable<Asset>> GetAvailableAssetsAsync();
    }
}
