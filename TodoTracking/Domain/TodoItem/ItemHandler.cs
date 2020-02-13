using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.TodoItem
{
    public class ItemHandler : ICanHandleCommands
    {
        readonly IAggregateOf<TodoList>  _aggregateSource;

        public ItemHandler(
            IAggregateOf<TodoList>  aggregateSource
        )
        {
             _aggregateSource =  aggregateSource;
        }

        public void Handle(CreateItem cmd)
        {
            var result = _aggregateSource
                .Create(cmd.List.Value)
                .Perform(_ => _.Add(cmd.Text));

            if (!result.IsSuccess)
            {
                // do something with the rules that failed
            }
        }

        public void Handle(DeleteItem cmd)
        {
            _aggregateSource
                .Rehydrate(cmd.List.Value)
                .Perform(_ => _.Remove(cmd.Text));
        }

        public void Handle(MarkItemAsDone cmd)
        {
            _aggregateSource
                .Rehydrate(cmd.List.Value)
                .Perform(_ => _.MarkAsDone(cmd.Text));
        }

        public void Handle(MarkItemAsNotDone cmd)
        {
            _aggregateSource
                .Rehydrate(cmd.List.Value)
                .Perform(_ => _.MarkAsNotDone(cmd.Text));
        }
    }
}
