using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.RequestModel
{
    public class DocumentRequest
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public int? Size { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? FolderId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
