using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Marx";
            command.LastName = "Teixeira";
            command.Document = "28659170377";
            command.Email = "email@email.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
