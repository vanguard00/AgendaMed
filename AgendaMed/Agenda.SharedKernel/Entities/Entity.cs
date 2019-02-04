using System;
using System.Collections.Generic;

namespace Agenda.SharedKernel.Entities
{
    public class Entity
    {
        public Dictionary<string, string> Notifications = new Dictionary<string, string>();

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatAt = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime CreatAt { get; private set; }
        public bool IsValid { get { return Notifications.Count > 0 ? false : true; } }

        public void AddNotification(string property, string message)
        {
            Notifications.Add(property, message);
        }
    }
}
