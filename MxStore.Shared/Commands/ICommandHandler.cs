﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
