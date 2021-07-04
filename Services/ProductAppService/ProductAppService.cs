using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.DataContext;
using app.api.DataContext.Models;
using app.api.DataContext.Repository;
using app.api.Services.ProductAppService.Dto;
using app.api.Services.ProductAppService.Requests;

namespace app.api.Services.ProductAppService
{
    public class ProductAppService : IProductAppService
    {
        private readonly IGenericRepository<DBDataContext> _genericRepository;
        public ProductAppService(IGenericRepository<DBDataContext> genericRepository)
        {
            ThrowIf.Argument.IsNull(genericRepository, nameof(genericRepository));

            _genericRepository = genericRepository;
        }
        public async Task<ProductDto> AddAsync(ProductRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));

            _genericRepository.Add<Product>(new Product
            {
                Description = request.Description
            });

            await _genericRepository.UnitOfWork.Commit();

            return new ProductDto
            {
                Description = request.Description,
                Code = 200,
                Message = "Product created"
            };
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            List<Product> products = await _genericRepository.GetAllAsync<Product>();

            return products.ProjectedAsCollection<ProductDto>();
        }

        public async Task<ProductDto> GetSingleAsync(int productId)
        {
            ThrowIf.Argument.IsNull(productId, nameof(productId));

            Product product = await _genericRepository.GetSingleAsync<Product>(s => s.Id == productId);

            if (product == null)
            {
                return new ProductDto
                {
                    Code = 404,
                    Message = "Product not found"
                };
            }

            return product.ProjectedAsItem<ProductDto>();
        }

        public async Task<ProductDto> RemoveAsync(int productId)
        {
            ThrowIf.Argument.IsNull(productId, nameof(productId));

            Product product = await _genericRepository.GetSingleAsync<Product>(s => s.Id == productId);

            if (product == null) return NotFount();

            _genericRepository.Remove<Product>(product);

            await _genericRepository.UnitOfWork.Commit();

            return new ProductDto
            {
                Code = 200,
                Message = "Product is deleted"
            }; ;
        }

        public async Task<ProductDto> ModifyAsync(ProductRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.Id, nameof(request.Id));

            Product product = await _genericRepository.GetSingleAsync<Product>(s => s.Id == request.Id);

            if (product == null) return NotFount();

            product.Description = request.Description;

            await _genericRepository.UnitOfWork.Commit();

            return new ProductDto
            {
                Code = 200,
                Message = "Product is modified"
            };
        }

        private ProductDto NotFount()
        {
            return new ProductDto
            {
                Code = 404,
                Message = "Product not found"
            };
        }
    }
}