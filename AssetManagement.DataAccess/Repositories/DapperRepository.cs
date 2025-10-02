using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AssetManagement.DataAccess.Interfaces;

namespace AssetManagement.DataAccess.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string not found");
        }

        public async Task<int> GetTotalAssetsCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Assets");
        }

        public async Task<int> GetAssignedAssetsCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Assets WHERE Status = @Status",
                new { Status = 1 }); // AssetStatus.Assigned = 1
        }

        public async Task<int> GetAvailableAssetsCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Assets WHERE Status = @Status",
                new { Status = 0 }); // AssetStatus.Available = 0
        }

        public async Task<int> GetUnderRepairCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Assets WHERE Status = @Status",
                new { Status = 2 }); // AssetStatus.UnderRepair = 2
        }

        public async Task<int> GetRetiredCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Assets WHERE Status = @Status",
                new { Status = 3 }); // AssetStatus.Retired = 3
        }

        public async Task<int> GetSpareAssetsCountAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Assets WHERE IsSpare = 1");
        }

        public async Task<Dictionary<string, int>> GetAssetsByTypeAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.QueryAsync<(string AssetType, int Count)>(
                "SELECT AssetType, COUNT(*) as Count FROM Assets GROUP BY AssetType");
            
            return result.ToDictionary(x => x.AssetType, x => x.Count);
        }
    }
}
