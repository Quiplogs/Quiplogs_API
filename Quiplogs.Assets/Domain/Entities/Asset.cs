using System;
using Quiplogs.Core.Domain.Entities;

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

        public string UoM { get; set; }

        public string ImageUrl { get; set; }

        public string WarrantyUrl { get; set; }

        public string InstructionManualUrl { get; set; }

        public int WordOrdersOpenCount { get; set; }

        public int WordOrdersInProgressCount { get; set; }

        public int WordOrdersCompletedCount { get; set; }

        public bool ShouldCaptureWorkDone { get; set; }

        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }
    }
}