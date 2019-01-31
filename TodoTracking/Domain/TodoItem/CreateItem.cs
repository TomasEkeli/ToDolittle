using Concepts.TodoItem;
using Dolittle.Commands;

namespace Domain.TodoItem
{
    public class CreateItem : ICommand
    {
        public ListId List { get; set; }
        public TodoText Text { get; set; }
    }
}
