using Dapper;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.Repositories;
using MxStore.Domain.StoreContext.ValueObjects;
using MxStore.Infra.StoreContext.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MxStore.Infra.StoreContext.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckDocument", 
                    new {Document = document}, 
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document,
                    Email = customer.Email,
                    Phone = customer.Phone,
                }, commandType: CommandType.StoredProcedure);

            foreach(var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type,
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
