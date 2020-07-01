using System;

namespace Api.UseCases.Asset.Put
{
    public class PutAssetRequest
    {
        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? ManufacuredDate { get; set; }

        public DateTime? PurchasedDate { get; set; }

        public decimal CurrentWorkDone { get; set; }

        public int UoM { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }

        public string WarrantyUrl { get; set; }

        public string InstructionManualUrl { get; set; }

        public string LocationId { get; set; }

        public string CompanyId { get; set; }
    }
}
