using Api.Core.Domain.Entities;
using System;

namespace Quiplogs.Assets.Domain.Entities
{
    public class Asset : BaseEntity
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

        public int WordOrdersOpenCount { get; set; }

        public int WordOrdersInProgressCount { get; set; }

        public int WordOrdersCompletedCount { get; set; }

        public bool ShouldCaptureWorkDone { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public string CompanyId { get; set; }
    }
}