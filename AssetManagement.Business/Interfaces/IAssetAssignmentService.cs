using AssetManagement.Models;

namespace AssetManagement.Business.Interfaces
{
    public interface IAssetAssignmentService
    {
        Task<IEnumerable<AssetAssignment>> GetAllAssignmentsAsync();
        Task<AssetAssignment?> GetAssignmentByIdAsync(int id);
        Task<AssetAssignment> AssignAssetAsync(int assetId, int employeeId, string notes);
        Task ReturnAssetAsync(int assignmentId);
        Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(int employeeId);
        Task<IEnumerable<AssetAssignment>> GetAssetHistoryAsync(int assetId);
    }
}
