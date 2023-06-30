using MxStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreatedDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public EDeliveryStatus Status { get; set; }
    }
}
