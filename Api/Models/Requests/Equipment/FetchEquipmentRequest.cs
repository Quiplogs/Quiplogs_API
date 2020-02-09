namespace Api.Models.Requests.Equipment
{
    public class FetchEquipmentRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public int PageNumber { get; set; }
    }
}
