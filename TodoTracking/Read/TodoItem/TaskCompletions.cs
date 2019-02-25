using System;
using System.Collections.Generic;
using Concepts.TodoItem;
using Dolittle.ReadModels;

namespace Read.TodoItem
{
    public class TaskCompletions : IReadModel
    {
        public ListId Id { get; set; }
        public IDictionary<TodoText, DateTime> TaskCompletion { get; set; }
            = new Dictionary<TodoText, DateTime>();
    }
}
