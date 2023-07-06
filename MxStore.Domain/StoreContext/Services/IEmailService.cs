using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}
