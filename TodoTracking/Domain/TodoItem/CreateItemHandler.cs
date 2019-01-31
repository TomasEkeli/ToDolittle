using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.TodoItem
{
    public class CreateItemHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<TodoList>  _aggregateRootRepoForTodoList;

        public CreateItemHandler(
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
        
    }
}
