using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("10902174630");
            invalidDocument = new Document("12345678901");
        }

        [TestMethod]
        public void DeveRetornarNotificacaoQuandoDocumentoInvalido()
        {
            
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoDocumentoValido()
        {
           
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
            
        }

        [TestMethod]
        public void DeveRetornarNotificacoQuandoNomeInvalido()
        {
            var name = new Name("", "Teixeira");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}
