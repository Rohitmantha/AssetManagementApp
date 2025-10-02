using AssetManagement.Business.Interfaces;
using AssetManagement.DataAccess.Interfaces;

namespace AssetManagement.Business.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDapperRepository _dapperRepository;

        public DashboardService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<int> GetTotalAssetsAsync()
        {
            return await _dapperRepository.GetTotalAssetsCountAsync();
        }

        public async Task<int> GetAssignedAssetsAsync()
        {
            return await _dapperRepository.GetAssignedAssetsCountAsync();
        }

        public async Task<int> GetAvailableAssetsAsync()
        {
            return await _dapperRepository.GetAvailableAssetsCountAsync();
        }

        public async Task<int> GetUnderRepairAsync()
        {
            return await _dapperRepository.GetUnderRepairCountAsync();
        }

        public async Task<int> GetRetiredAsync()
        {
            return await _dapperRepository.GetRetiredCountAsync();
        }

        public async Task<int> GetSpareAssetsAsync()
        {
            return await _dapperRepository.GetSpareAssetsCountAsync();
        }

        public async Task<Dictionary<string, int>> GetAssetsByTypeAsync()
        {
            return await _dapperRepository.GetAssetsByTypeAsync();
        }
    }
}
