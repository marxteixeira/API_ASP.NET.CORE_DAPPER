using Microsoft.AspNetCore.Mvc;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MxStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name2 = new Name("Teste", "Teixeira");
            var document2 = new Document("109021746845");
            var email2 = new Email("email@email.com");
            var customer2 = new Customer(name2, document2, email2, "32984848484");

            var name = new Name("Marx", "Teixeira");
            var document = new Document("109021746845");
            var email = new Email("email@email.com");
            var customer = new Customer(name, document, email, "32984848484");
            var customers = new List<Customer>();
            customers.Add(customer);
            customers.Add(customer2);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name2 = new Name("Teste", "Teixeira");
            var document2 = new Document("109021746845");
            var email2 = new Email("email@email.com");
            var customer2 = new Customer(name2, document2, email2, "32984848484");

            return customer2;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Marx", "Teixeira");
            var document = new Document("109021746845");
            var email = new Email("email@email.com");
            var customer = new Customer(name, document, email, "32984848484");

            var order = new Order(customer);
            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var monitor = new Product("monitor Gamer", "monitor Gamer", "momonitoruse.jpg", 100M, 10);
            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            var orders = new List<Order>();
            orders.Add(order);


            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new {message = "Cliente removido com sucesso."};
        }



    }
}
