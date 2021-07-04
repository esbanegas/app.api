namespace app.api.Services.ClientService.Request
{
    public class ClientRequest
    {
        public int IdClient { get; set; }
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public bool State { get; set; }
    }
}