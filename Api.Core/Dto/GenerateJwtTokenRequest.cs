namespace Quiplogs.Core.Dto
{
    public class GenerateJwtTokenRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
    }
}