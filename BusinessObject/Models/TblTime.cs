using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblTime
    {
        public TblTime()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public string TimeId { get; set; } = null!;
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TiemEnd { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
