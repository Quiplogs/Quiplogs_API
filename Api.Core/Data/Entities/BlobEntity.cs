using System;

namespace Quiplogs.Core.Data.Entities
{
    public class BlobEntity : BaseEntityDto
    {
        public Guid ForeignKeyId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string FileUrl { get; set; }
        public string ApplicationType { get; set; }
    }
}
