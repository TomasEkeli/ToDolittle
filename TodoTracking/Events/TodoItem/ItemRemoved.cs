using System;
using Dolittle.Events;

namespace Events.TodoItem
{
    public class ItemRemoved : IEvent
    {
        public ItemRemoved(Guid listId, string text)
        {
            ListId = listId;
            Text = text;
        }

        public Guid ListId { get; }
        public string Text { get; }
    }
}
