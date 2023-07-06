using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}
