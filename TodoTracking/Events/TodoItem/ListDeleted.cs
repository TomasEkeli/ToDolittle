using System;
using Dolittle.Events;

namespace Events.TodoItem
{
    public class ListDeleted : IEvent
    {
        public ListDeleted(Guid listId)
        {
            ListId = listId;
        }

        public Guid ListId { get; }
    }
}
