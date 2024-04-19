using RealEstate_Dapper_Api.Dtos.TypeDtos;

namespace RealEstate_Dapper_Api.Repositories.TypeRepositories
{
    public interface ITypeRepository
    {
        Task<List<ResultTypeDto>> GetAllTypeAsync();
    }
}
