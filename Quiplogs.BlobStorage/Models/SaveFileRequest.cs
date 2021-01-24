using System;

namespace Quiplogs.BlobStorage.Models
{
    public class SaveFileRequest
    {
        public string Container { get; set; }
        public string SubContainer { get; set; }
        public string FileName { get; set; }
        public string FileBase64 { get; set; }
        public string MimeType { get; set; }
    }
}
