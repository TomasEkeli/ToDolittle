using System;
using Concepts.TodoItem;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.TodoItem;

namespace Domain.TodoItem
{
    public class TodoList : AggregateRoot
    {
        public TodoList(EventSourceId id) : base(id)
        { 
            
        }

        public void Add(TodoText text)
        {
            var createdEvent = new ItemCreated(
                EventSourceId,
                text
            );

            Apply(createdEvent);
        }
    }
}
