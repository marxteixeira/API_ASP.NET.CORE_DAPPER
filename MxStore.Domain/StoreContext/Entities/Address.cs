﻿using FluentValidator;
using MxStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Entities
{
    public class Address : Notifiable
    {
        public Address(string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}
