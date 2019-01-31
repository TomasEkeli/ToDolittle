using Dolittle.Concepts;

namespace Concepts.TodoItem
{
    public class TodoTask : Value<TodoTask>
    {
        public TaskStatus Status { get; set; } = TaskStatus.NotDone;
        public TodoText Text { get; set; }
    }
}
