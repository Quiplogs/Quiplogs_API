using System;
using System.Collections.Generic;
using System.Text;

namespace Quiplogs.BlobStorage.Models
{
    public class DeleteFileRequest
    {
        public string Container { get; set; }
        public string SubContainer { get; set; }
        public string FileName { get; set; }
    }
}
