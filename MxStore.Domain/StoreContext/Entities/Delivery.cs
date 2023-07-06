using MxStore.Domain.StoreContext.Enums;
using MxStore.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreatedDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public EDeliveryStatus Status { get; set; }

        public void Ship()
        {
            //se a data estimada de entrega for no passado, não entregar.
            Status = EDeliveryStatus.Shipped;
        }

        //cancelar um pedido
        public void Cancel()
        {
            // se o status já estiver entregue, não pode cancelar.
            Status = EDeliveryStatus.Canceled;
        }
    }
}
