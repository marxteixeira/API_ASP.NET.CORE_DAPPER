using Microsoft.AspNetCore.Mvc;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.Handlers;
using MxStore.Domain.StoreContext.Queries;
using MxStore.Domain.StoreContext.Repositories;
using MxStore.Domain.StoreContext.ValueObjects;
using SQLitePCL;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MxStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {          
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {   
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);

            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
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
