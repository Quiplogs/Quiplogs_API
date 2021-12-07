using System;

namespace Quiplogs.Core.Interfaces
{
    public interface IImage
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string ImageFileName { get; set; }
    }
}
