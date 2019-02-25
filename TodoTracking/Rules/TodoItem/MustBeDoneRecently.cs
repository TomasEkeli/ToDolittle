using System;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.TodoItem;

namespace Rules.TodoItem
{
    public class MustBeDoneRecently
    : IRuleImplementationFor<Domain.TodoItem.MustBeDoneRecently>
    {
        readonly IReadModelRepositoryFor<TaskCompletions> _repository;
        readonly TimeSpan _allowUndosFor = TimeSpan.FromHours(24);

        public MustBeDoneRecently(IReadModelRepositoryFor<TaskCompletions> repository)
        {
            _repository = repository;
        }

        public Domain.TodoItem.MustBeDoneRecently Rule => 
            (list, text) => 
            {
                var completions = _repository.GetById(list);

                if (completions == null) 
                {
                    return false;
                }

                return completions.TaskCompletion.TryGetValue(text, out var completedAt)
                    ? DateTime.UtcNow - completedAt < _allowUndosFor
                    : false;
            };
    }
}