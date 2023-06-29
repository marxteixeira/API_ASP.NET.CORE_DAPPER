using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, string document, string email, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
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
