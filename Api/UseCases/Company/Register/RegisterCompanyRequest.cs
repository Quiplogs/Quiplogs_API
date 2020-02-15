namespace Api.UseCases.Company.Register
{
    public class RegisterCompanyRequest
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNumber { get; set; }

        public string LicenceNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int SubscriptionId { get; set; }

        public string LastName { get; set; }
    }
}
