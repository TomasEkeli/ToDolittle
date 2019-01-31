using System;
using Dolittle.Events;
using Dolittle.Runtime.Events;

namespace Events.TodoItem
{
    public class ItemCreated : IEvent
    {
        public ItemCreated(Guid listId, string text)
        {
            ListId = listId;
            Text = text;
        }

        public Guid ListId { get; }
        public string Text { get; }
    }
}
