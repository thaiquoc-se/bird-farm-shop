using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblOrderDetail
    {
        public string OrderId { get; set; } = null!;
        public string BirdId { get; set; } = null!;
        public string? TimeId { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public string? CostsIncurred { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TblOrder Order { get; set; } = null!;
    }
}
