using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public DateTime BuildTime { get; set; }
        public string Comment1 { get; set; }
        public int StarRank { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}
