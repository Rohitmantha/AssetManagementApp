using AssetManagement.Business.Interfaces;
using AssetManagement.DataAccess.Interfaces;
using AssetManagement.Models;

namespace AssetManagement.Business.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private readonly IAssetAssignmentRepository _assignmentRepository;
        private readonly IAssetRepository _assetRepository;

        public AssetAssignmentService(
            IAssetAssignmentRepository assignmentRepository,
            IAssetRepository assetRepository)
        {
            _assignmentRepository = assignmentRepository;
            _assetRepository = assetRepository;
        }

        public async Task<IEnumerable<AssetAssignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<AssetAssignment?> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<AssetAssignment> AssignAssetAsync(int assetId, int employeeId, string notes)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId);
            if (asset == null)
                throw new KeyNotFoundException($"Asset with ID {assetId} not found");

            if (asset.Status != AssetStatus.Available)
                throw new InvalidOperationException("Asset is not available for assignment");

            // Create assignment
            var assignment = new AssetAssignment
            {
                AssetId = assetId,
                EmployeeId = employeeId,
                AssignedDate = DateTime.Now,
                Notes = notes ?? string.Empty
            };

            await _assignmentRepository.AddAsync(assignment);

            // Update asset status
            asset.Status = AssetStatus.Assigned;
            await _assetRepository.UpdateAsync(asset);

            return assignment;
        }

        public async Task ReturnAssetAsync(int assignmentId)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(assignmentId);
            if (assignment == null)
                throw new KeyNotFoundException($"Assignment with ID {assignmentId} not found");

            if (assignment.ReturnedDate != null)
                throw new InvalidOperationException("Asset already returned");

            assignment.ReturnedDate = DateTime.Now;
            await _assignmentRepository.UpdateAsync(assignment);

            // Update asset status
            var asset = await _assetRepository.GetByIdAsync(assignment.AssetId);
            if (asset != null)
            {
                asset.Status = AssetStatus.Available;
                await _assetRepository.UpdateAsync(asset);
            }
        }

        public async Task<IEnumerable<AssetAssignment>> GetEmployeeAssignmentsAsync(int employeeId)
        {
            return await _assignmentRepository.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<IEnumerable<AssetAssignment>> GetAssetHistoryAsync(int assetId)
        {
            return await _assignmentRepository.GetByAssetIdAsync(assetId);
        }
    }
}
