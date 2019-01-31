using Concepts.TodoItem;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.TodoItem;

namespace Read.TodoItem
{
    public class ItemCreatedProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<TaskList> _repositoryForTaskList;

        public ItemCreatedProcessor(
            IReadModelRepositoryFor<TaskList> repositoryForTaskList            
        )
        {
            _repositoryForTaskList = repositoryForTaskList;
        }
        
        [EventProcessor("32dcfb33-8381-f278-daf5-40fa641f7435")]
        public void Process(ItemCreated evt)
        { 
            var taskList = _repositoryForTaskList.GetById(evt.ListId);

            if (taskList == null)
            {
                taskList = new TaskList
                {
                    Id = evt.ListId,
                    Tasks = new []
                    {
                        new TodoTask
                        {
                            Text = evt.Text
                        }
                    }
                };

                _repositoryForTaskList.Insert(taskList);
            }
            else
            {
                taskList.Tasks.Add(new TodoTask
                {
                    Text = evt.Text
                });

                _repositoryForTaskList.Update(taskList);
            }
        }
        
    }
}
