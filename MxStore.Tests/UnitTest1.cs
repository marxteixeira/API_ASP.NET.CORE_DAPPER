using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxStore.Domain.StoreContext;
using MxStore.Domain.StoreContext.Entities;

namespace MxStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customer = new Customer(
                "Marx",
                "Teixeira",
                "10902174633",
                "email@email.com",
                "32984629999",
                "Rua dos Developers, 10"
                );

            var order = new Order();
            order.Items.Add
        }
    }
}
