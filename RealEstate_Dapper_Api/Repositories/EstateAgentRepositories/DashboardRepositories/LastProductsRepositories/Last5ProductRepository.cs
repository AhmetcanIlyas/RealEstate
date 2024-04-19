using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;
        public Last5ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "SELECT Top(5) ProductID,Title,Price,City,District,CategoryName,TypeName,AdvertisementDate FROM Product " +
                "INNER JOIN Category ON Product.ProductCategory = Category.CategoryID INNER JOIN Type ON Product.ProductType = Type.TypeID " +
                "Where EmployeeID=@employeeID ORDER BY ProductID DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
