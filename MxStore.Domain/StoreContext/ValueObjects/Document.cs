using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.ValueObjects
{
    public class Document
    {
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
