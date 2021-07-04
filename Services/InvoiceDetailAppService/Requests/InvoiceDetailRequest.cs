namespace app.api.Services.InvoiceDetailAppService.Requests
{
    public class InvoiceDetailRequest
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public int? IdClient { get; set; }

        public int? IdInvoice { get; set; }
        public float? Quantity { get; set; }
        public float? SubTotal { get; set; }
    }
}