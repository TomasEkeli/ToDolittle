using Dolittle.Concepts;

namespace Concepts.TodoItem
{
    public class TodoTask : Value<TodoTask>
    {
        public TodoText Text { get; set; }
    }
}
