using Microsoft.EntityFrameworkCore;
using AssetManagement.DataAccess.Data;
using AssetManagement.DataAccess.Interfaces;
using AssetManagement.Models;

namespace AssetManagement.DataAccess.Repositories
{
    public class AssetAssignmentRepository : IAssetAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetAssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssetAssignment>> GetAllAsync()
        {
            return await _context.AssetAssignments
                .Include(aa => aa.Asset)
                .Include(aa => aa.Employee)
                .OrderByDescending(aa => aa.AssignedDate)
                .ToListAsync();
        }

        public async Task<AssetAssignment?> GetByIdAsync(int id)
        {
            return await _context.AssetAssignments
                .Include(aa => aa.Asset)
                .Include(aa => aa.Employee)
                .FirstOrDefaultAsync(aa => aa.AssignmentId == id);
        }

        public async Task<AssetAssignment> AddAsync(AssetAssignment assignment)
        {
            _context.AssetAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task UpdateAsync(AssetAssignment assignment)
        {
            _context.AssetAssignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssetAssignment>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.AssetAssignments
                .Include(aa => aa.Asset)
                .Where(aa => aa.EmployeeId == employeeId)
                .OrderByDescending(aa => aa.AssignedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssetAssignment>> GetByAssetIdAsync(int assetId)
        {
            return await _context.AssetAssignments
                .Include(aa => aa.Employee)
                .Where(aa => aa.AssetId == assetId)
                .OrderByDescending(aa => aa.AssignedDate)
                .ToListAsync();
        }
    }
}
