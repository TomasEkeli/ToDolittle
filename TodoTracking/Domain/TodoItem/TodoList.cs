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

        public void Remove(TodoText text)
        {
            var createdEvent = new ItemRemoved(
                EventSourceId,
                text
            );

            Apply(createdEvent);
        }

        public void MarkAsDone(TodoText text)
        {
            var createdEvent = new ItemDone(
                EventSourceId,
                text
            );

            Apply(createdEvent);
        }

        public void MarkAsNotDone(TodoText text)
        {
            var createdEvent = new ItemNotDone(
                EventSourceId,
                text
            );

            Apply(createdEvent);
        }
    }
}
