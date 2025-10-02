using AssetManagement.Models;

namespace AssetManagement.DataAccess.Interfaces
{
    public interface IAssetAssignmentRepository
    {
        Task<IEnumerable<AssetAssignment>> GetAllAsync();
        Task<AssetAssignment?> GetByIdAsync(int id);
        Task<AssetAssignment> AddAsync(AssetAssignment assignment);
        Task UpdateAsync(AssetAssignment assignment);
        Task<IEnumerable<AssetAssignment>> GetByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<AssetAssignment>> GetByAssetIdAsync(int assetId);
    }
}
