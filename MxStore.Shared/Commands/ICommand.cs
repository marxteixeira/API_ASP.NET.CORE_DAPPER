using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
