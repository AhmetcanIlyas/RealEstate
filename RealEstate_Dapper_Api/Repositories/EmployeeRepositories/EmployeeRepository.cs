using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values(@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.Name);
            parameters.Add("@title", createEmployeeDto.Title);
            parameters.Add("@mail", createEmployeeDto.Mail);
            parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeDto updateEmployeDto)
        {
            string queary = "Update Employee Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeDto.Name);
            parameters.Add("@title", updateEmployeDto.Title);
            parameters.Add("@mail", updateEmployeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeDto.ImageUrl);
            parameters.Add("@status", updateEmployeDto.Status);
            parameters.Add("@employeeID", updateEmployeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(queary, parameters);
            }
        }
    }
}
