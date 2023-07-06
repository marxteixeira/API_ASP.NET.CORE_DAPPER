using MxStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}
