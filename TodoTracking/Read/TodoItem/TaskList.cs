using System.Collections.Generic;
using Concepts.TodoItem;
using Dolittle.ReadModels;

namespace Read.TodoItem
{
    public class TaskList : IReadModel
    {
        public ListId Id { get; set; }
        public IList<TodoTask> Tasks { get; set; }
    }
}
