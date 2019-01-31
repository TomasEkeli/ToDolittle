using Concepts.TodoItem;
using Dolittle.Commands;

namespace Domain.TodoItem
{
    public class ClearList : ICommand
    {
        public ListId List { get; set; }
    }
}
