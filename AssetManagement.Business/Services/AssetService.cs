using AssetManagement.Business.Interfaces;
using AssetManagement.DataAccess.Interfaces;
using AssetManagement.Models;

namespace AssetManagement.Business.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Asset?> GetAssetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Asset> CreateAssetAsync(Asset asset)
        {
            if (string.IsNullOrWhiteSpace(asset.AssetName))
                throw new ArgumentException("Asset name is required");

            if (string.IsNullOrWhiteSpace(asset.SerialNumber))
                throw new ArgumentException("Serial number is required");

            return await _repository.AddAsync(asset);
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            if (!await _repository.ExistsAsync(asset.AssetId))
                throw new KeyNotFoundException($"Asset with ID {asset.AssetId} not found");

            await _repository.UpdateAsync(asset);
        }

        public async Task DeleteAssetAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException($"Asset with ID {id} not found");

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync()
        {
            return await _repository.GetAvailableAssetsAsync();
        }
    }
}
