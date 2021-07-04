using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Services.ProductAppService.Dto;
using app.api.Services.ProductAppService.Requests;

namespace app.api.Services.ProductAppService
{
    public interface IProductAppService
    {
        Task<ProductDto> GetSingleAsync(int productId);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> AddAsync(ProductRequest request);
        Task<ProductDto> RemoveAsync(int productId);
        Task<ProductDto> ModifyAsync(ProductRequest request);
    }
}