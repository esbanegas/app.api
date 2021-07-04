
using app.api.DataContext.BaseEntities;

namespace app.api.DataContext.Models
{
    public partial class Product : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}