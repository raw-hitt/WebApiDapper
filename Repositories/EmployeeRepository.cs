using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiDapper.Models;

namespace WebApiDapper.Repositories
{



    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Employees";
            return await connection.QueryAsync<Employee>(query);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Employees WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
        }

        public async Task<int> CreateAsync(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"
            INSERT INTO Employees (Name, Department, Email, Salary, DateOfJoining)
            VALUES (@Name, @Department, @Email, @Salary, @DateOfJoining)";
            return await connection.ExecuteAsync(query, employee);
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"
            UPDATE Employees 
            SET Name = @Name, Department = @Department, Email = @Email, Salary = @Salary, DateOfJoining = @DateOfJoining 
            WHERE Id = @Id";
            return await connection.ExecuteAsync(query, employee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "DELETE FROM Employees WHERE Id = @Id";
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}