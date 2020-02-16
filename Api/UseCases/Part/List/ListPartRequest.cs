using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.Part.List
{
    public class ListPartRequest
    {
        public string CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
