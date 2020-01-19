using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Domain.Entities
{
    public class Equipment
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public decimal CurrentWorkDone { get; set; }

        public string UoM { get; set; }

        public decimal WorkDoneToday { get; set; }
    }
}
