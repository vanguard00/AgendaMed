using FluentValidator;
using System;

namespace Agenda.SharedKernel.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatAt = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime CreatAt { get; private set; }
    }
}
