﻿using Microsoft.AspNetCore.Mvc;
using MxStore.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;

namespace MxStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public List<Customer> GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public string Delete()
        {
            return null;
        }



    }
}
