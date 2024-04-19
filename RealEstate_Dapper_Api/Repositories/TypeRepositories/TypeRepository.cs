using Dapper;
using RealEstate_Dapper_Api.Dtos.TypeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TypeRepositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly Context _context;
        public TypeRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTypeDto>> GetAllTypeAsync()
        {
            string query = "Select * From Type";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTypeDto>(query);
                return values.ToList();
            }
        }
    }
}
