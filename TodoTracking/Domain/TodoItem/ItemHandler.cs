using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.TodoItem
{
    public class ItemHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<TodoList>  _aggregateRootRepoForTodoList;

        public ItemHandler(
            IAggregateRootRepositoryFor<TodoList>  aggregateRootRepoForTodoList            
        )
        {
             _aggregateRootRepoForTodoList =  aggregateRootRepoForTodoList;
        }

        public void Handle(CreateItem cmd)
        {
            var todoList = _aggregateRootRepoForTodoList.Get(cmd.List.Value);

            todoList.Add(cmd.Text);
        }

        public void Handle(DeleteItem cmd)
        {
            var todoList = _aggregateRootRepoForTodoList.Get(cmd.List.Value);

            todoList.Remove(cmd.Text);
        }

        public void Handle(MarkItemAsDone cmd)
        {
            var todoList = _aggregateRootRepoForTodoList.Get(cmd.List.Value);

            todoList.MarkAsDone(cmd.Text);
        }

        public void Handle(MarkItemAsNotDone cmd)
        {
            var todoList = _aggregateRootRepoForTodoList.Get(cmd.List.Value);

            todoList.MarkAsNotDone(cmd.Text);
        }
        
    }
}
