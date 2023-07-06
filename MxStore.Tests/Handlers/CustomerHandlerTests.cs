using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MxStore.Domain.StoreContext.Handlers;
using MxStore.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Tests.Handlers
{
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void DeveRegistrarClienteQuandoComandoValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Marx";
            command.LastName = "Teixeira";
            command.Document = "10902174680";
            command.Email = "andrebaltieri@gmail.com";
            command.Phone = "32984629494";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

        }
    }
}
