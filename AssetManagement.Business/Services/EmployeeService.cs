using AssetManagement.Business.Interfaces;
using AssetManagement.DataAccess.Interfaces;
using AssetManagement.Models;

namespace AssetManagement.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            // Business validation
            if (string.IsNullOrWhiteSpace(employee.FullName))
                throw new ArgumentException("Full name is required");

            if (string.IsNullOrWhiteSpace(employee.Email))
                throw new ArgumentException("Email is required");

            return await _repository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (!await _repository.ExistsAsync(employee.EmployeeId))
                throw new KeyNotFoundException($"Employee with ID {employee.EmployeeId} not found");

            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException($"Employee with ID {id} not found");

            await _repository.DeleteAsync(id);
        }
    }
}
