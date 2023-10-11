using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblComment
    {
        public string CommentId { get; set; } = null!;
        public string BirdId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime? CommentDate { get; set; }
        public string? Content { get; set; }
        public int? Rating { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
