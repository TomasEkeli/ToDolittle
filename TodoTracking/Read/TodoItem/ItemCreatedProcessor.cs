using System.Linq;
using Concepts.TodoItem;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.TodoItem;

namespace Read.TodoItem
{
    public class ItemChangeProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<TaskList> _repositoryForTaskList;

        public ItemChangeProcessor(
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
                            Text = evt.Text,
                        }
                    }
                };

                _repositoryForTaskList.Insert(taskList);
            }
            else
            {
                taskList.Tasks.Add(new TodoTask
                {
                    Text = evt.Text,
                });

                _repositoryForTaskList.Update(taskList);
            }
        }
        
        
        [EventProcessor("BF3ACC31-6005-40B2-AFD8-05952706DC3E")]
        public void Process(ItemRemoved evt)
        { 
            var taskList = _repositoryForTaskList.GetById(evt.ListId);

            var taskToRemove = 
                taskList
                    .Tasks
                    .FirstOrDefault(task => task.Text == evt.Text);

            taskList.Tasks.Remove(taskToRemove);

            _repositoryForTaskList.Update(taskList);
        }
        
        [EventProcessor("BF7E1935-9203-4E5A-BD05-FC65D2785866")]
        public void Process(ItemDone evt)
        { 
            var taskList = _repositoryForTaskList.GetById(evt.ListId);

            var taskThatIsDone = 
                taskList
                    .Tasks
                    .FirstOrDefault(task => task.Text == evt.Text)
                    .Status = TaskStatus.Done;

            _repositoryForTaskList.Update(taskList);
        }
        
        [EventProcessor("4696FA10-02EB-45E0-B9DC-A53D3171D257")]
        public void Process(ItemNotDone evt)
        { 
            var taskList = _repositoryForTaskList.GetById(evt.ListId);

            var taskThatIsDone = 
                taskList
                    .Tasks
                    .FirstOrDefault(task => task.Text == evt.Text)
                    .Status = TaskStatus.NotDone;

            _repositoryForTaskList.Update(taskList);
        }
    }
}
