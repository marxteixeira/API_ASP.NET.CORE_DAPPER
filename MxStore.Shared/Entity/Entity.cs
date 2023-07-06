using FluentValidator;
using System;

namespace MxStore.Shared.Entity
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
