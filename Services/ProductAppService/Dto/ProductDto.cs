using app.api.Core.Dto;

namespace app.api.Services.ProductAppService.Dto
{
    public class ProductDto : BaseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}