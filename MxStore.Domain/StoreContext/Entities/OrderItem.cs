﻿using FluentValidator;
using MxStore.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if(product.QuantityOnHand < quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque.");
            }

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
