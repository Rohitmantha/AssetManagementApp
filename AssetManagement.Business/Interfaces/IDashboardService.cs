namespace AssetManagement.Business.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetTotalAssetsAsync();
        Task<int> GetAssignedAssetsAsync();
        Task<int> GetAvailableAssetsAsync();
        Task<int> GetUnderRepairAsync();
        Task<int> GetRetiredAsync();
        Task<int> GetSpareAssetsAsync();
        Task<Dictionary<string, int>> GetAssetsByTypeAsync();
    }
}
