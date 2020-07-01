using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Responses.Asset;
using System;

namespace Quiplogs.Assets.Dto.Requests.Asset
{
    public class PutAssetRequest : IRequest<PutAssetResponse>
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

        public PutAssetRequest(string name, string make, string model, string serialNumber, DateTime? manufacturedDate, DateTime? purchasedDate, decimal currentWorkDone, int uom, string imgFileName, string imgUrl, string warrantyUrl, string instructionManualUrl, string locationId, string companyId)
        {
            Name = name;
            Make = make;
            Model = model;
            SerialNumber = serialNumber;
            ManufacuredDate = manufacturedDate;
            PurchasedDate = purchasedDate;
            CurrentWorkDone = currentWorkDone;
            UoM = uom;
            ImgFileName = imgFileName;
            ImgUrl = imgUrl;
            WarrantyUrl = warrantyUrl;
            InstructionManualUrl = instructionManualUrl;
            LocationId = locationId;
            CompanyId = companyId;
        }
    }
}
