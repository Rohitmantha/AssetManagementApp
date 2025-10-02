namespace AssetManagement.DataAccess.Interfaces
{
    public interface IDapperRepository
    {
        Task<int> GetTotalAssetsCountAsync();
        Task<int> GetAssignedAssetsCountAsync();
        Task<int> GetAvailableAssetsCountAsync();
        Task<int> GetUnderRepairCountAsync();
        Task<int> GetRetiredCountAsync();
        Task<int> GetSpareAssetsCountAsync();
        Task<Dictionary<string, int>> GetAssetsByTypeAsync();
    }
}
