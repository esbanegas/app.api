using app.api.Core.Dto;

namespace app.api.Services.ClientService.Dto
{
    public class ClientDto : BaseDto
    {
        public int IdClient { get; set; }
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public bool State { get; set; }
    }
}