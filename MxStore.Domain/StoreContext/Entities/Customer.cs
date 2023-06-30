﻿using MxStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, string document, string email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();

        }

        public Name Name { get; set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray(); //ou { get {return _address.ToArray();} }
        public DateTime BirthDate { get; private set; }
        public decimal Salary { get; private set; }

        public void AddAddress(Address address)
        {
            //validar o endereço
            //adicionar o endereço
            _addresses.Add(address);

        }

        public void OnRegister()
        {
            ToString();
        }

        public override string ToString()
        {
            return $"{Name.FirstName}{Name.LastName}";
        }
    }
}
