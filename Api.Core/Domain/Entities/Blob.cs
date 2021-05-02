using System;

namespace Quiplogs.Core.Domain.Entities
{
    public class Blob : BaseEntity
    {
        public Guid ForeignKeyId { get; set; }
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string MimeType { get; set; }
        public string FileUrl { get; set; }
        public string ApplicationType { get; set; }
    }
}
