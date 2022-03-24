using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class Qa
    {
        public int QaId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Sort { get; set; }
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
