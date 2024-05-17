using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepoesitories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIDDto>> GetProductImageByProductID(int id);
    }
}
