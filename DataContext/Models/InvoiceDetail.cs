using System.ComponentModel.DataAnnotations.Schema;
using app.api.DataContext.BaseEntities;

namespace app.api.DataContext.Models
{
    public partial class InvoiceDetail : Entity
    {
        public int Id { get; set; }


        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public int? IdProduct { get; set; }


        public virtual Client Client { get; set; }

        [ForeignKey("Client")]
        public int? IdClient { get; set; }


        public virtual Invoice Invoice { get; set; }
        [ForeignKey("Invoice")]
        public int? IdInvoice { get; set; }
        

        public float? Quantity { get; set; }
        public float? SubTotal { get; set; }
    }
}