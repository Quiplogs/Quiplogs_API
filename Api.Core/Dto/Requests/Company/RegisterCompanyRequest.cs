using Quiplogs.Core.Dto.Responses.Company;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Company
{
    public class RegisterCompanyRequest : IRequest<RegisterCompanyResponse>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string TaxNumber { get; set; }

        public string LicenceNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public int SubscriptionId { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
    }
}
