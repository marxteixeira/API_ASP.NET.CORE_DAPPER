using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.Queries;
using MxStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}
