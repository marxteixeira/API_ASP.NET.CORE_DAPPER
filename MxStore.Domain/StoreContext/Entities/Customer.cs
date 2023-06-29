using MxStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(Name name, string document, string email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Addresses = new List<Address>();

        }

        public Name Name { get; set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal Salary { get; private set; }

        public void OnRegister()
        {
            ToString();
        }

        public override string ToString()
        {
            return $"{FirstName}{LastName}";
        }
    }
}
