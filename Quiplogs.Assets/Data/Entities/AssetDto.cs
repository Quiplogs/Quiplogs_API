﻿using System;
using Quiplogs.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Assets.Data.Entities
{
    public class AssetDto : BaseLocationDto
    {
        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? ManufacuredDate { get; set; }

        public DateTime? PurchasedDate { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrentWorkDone { get; set; }

        public string UoM { get; set; }
    }
}
