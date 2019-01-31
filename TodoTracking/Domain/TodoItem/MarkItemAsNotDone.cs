using Concepts.TodoItem;
using Dolittle.Commands;

namespace Domain.TodoItem
{
    public class MarkItemAsNotDone : ICommand
    {
        public ListId List { get; set; }
        public TodoText Text { get; set; }
    }
}
