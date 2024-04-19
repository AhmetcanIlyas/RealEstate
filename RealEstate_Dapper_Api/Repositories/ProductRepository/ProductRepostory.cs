using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepostory : IProductRepository
    {
        private readonly Context _context;
        public ProductRepostory(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "SELECT ProductID,Title,Price,City,District,CategoryName,CoverImage,TypeName,Address,DealOfTheDay FROM Product " +
                "INNER JOIN Category ON Product.ProductCategory = Category.CategoryID INNER JOIN Type ON Product.ProductType = Type.TypeID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "SELECT Top(5) ProductID,Title,Price,City,District,CategoryName,TypeName,AdvertisementDate FROM Product " +
                "INNER JOIN Category ON Product.ProductCategory = Category.CategoryID INNER JOIN Type ON Product.ProductType = Type.TypeID ORDER BY ProductID DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsync(int id)
        {
            string query = "SELECT ProductID,Title,Price,City,District,CategoryName,CoverImage,TypeName,Address,DealOfTheDay FROM Product " +
                "INNER JOIN Category ON Product.ProductCategory = Category.CategoryID INNER JOIN Type ON Product.ProductType = Type.TypeID " +
                "where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string queary = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(queary, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string queary = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(queary, parameters);
            }
        }
    }
}
