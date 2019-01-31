using System.Linq;
using Concepts.TodoItem;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.TodoItem;

namespace Rules.TodoItem
{
    public class MustBeDoneOnTheList
    : IRuleImplementationFor<Domain.TodoItem.MustBeDoneOnTheList>
    {
        private IReadModelRepositoryFor<TaskList> _repository;

        public MustBeDoneOnTheList(IReadModelRepositoryFor<TaskList> repository)
        {
            _repository = repository;
        }

        public Domain.TodoItem.MustBeDoneOnTheList Rule => 
            (list, text) => 
            {
                var stored_list = _repository.GetById(list);

                var task = stored_list.Tasks.FirstOrDefault(t => t.Text == text);

                return task?.Status == TaskStatus.Done;
            };
    }
}