using MxStore.Domain.StoreContext.Entities;
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
    }
}
