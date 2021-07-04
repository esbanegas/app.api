using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.Services.ProductAppService;
using app.api.Services.ProductAppService.Dto;
using app.api.Services.ProductAppService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{

    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            ThrowIf.Argument.IsNull(productAppService, nameof(productAppService));

            _productAppService = productAppService;
        }

        [HttpGet("all")]
        public async Task<List<ProductDto>> GetAllAync()
        {
            return await _productAppService.GetAllAsync();
        }

        [HttpGet("{productId:int}")]
        public async Task<ProductDto> GetSingleAync(int productId)
        {
            return await _productAppService.GetSingleAsync(productId);
        }

        [HttpPost]
        public async Task<ProductDto> AddAsync(ProductRequest request)
        {
            return await _productAppService.AddAsync(request);
        }

        [HttpDelete("{productId:int}")]
        public async Task<ProductDto> RemoveAync(int productId)
        {
            return await _productAppService.RemoveAsync(productId);
        }

        [HttpPut]
        public async Task<ProductDto> RemoveAsync(ProductRequest request){
            return await _productAppService.ModifyAsync(request);
        }
    }
}