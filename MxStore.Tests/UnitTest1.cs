using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxStore.Domain.StoreContext;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.ValueObjects;

namespace MxStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Marx", "Teixeira");
            var document = new Document("12345678911");
            var email = new Email("email@email.com");
            var c = new Customer(name, document, email, "1999207414");
            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "image.png", 559.90M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(cadeira, 5));
            //order.AddItem(new OrderItem(impressora, 5));

            //realizei o pedido
            order.Place();

            //verificar se o pedido é válido
            var valid = order.IsValid;

            //simular o pagamento
            order.Pay();

            //simular o envio
            order.Ship();

            //simular o cancelamento
            order.Cancel();

           

        }
    }
}
