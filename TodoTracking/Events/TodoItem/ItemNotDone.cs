using System;
using Dolittle.Events;

namespace Events.TodoItem
{
    public class ItemNotDone : IEvent
    {
        public ItemNotDone(Guid listId, string text)
        {
            ListId = listId;
            Text = text;
        }

        public Guid ListId { get; }
        public string Text { get; }
    }
}
