using System;
using System.Collections.Generic;
using Concepts.TodoItem;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.TodoItem;

namespace Read.TodoItem
{
    public class ItemCompletionTimeProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<TaskCompletions> _taskCompletions;

        public ItemCompletionTimeProcessor(IReadModelRepositoryFor<TaskCompletions> taskCompletions)
        {
            _taskCompletions = taskCompletions;
        }

        [EventProcessor("A1DFE86D-30A8-4926-B054-D4502702B393")]
        public void Process(ItemDone evt)
        {
            var completions = _taskCompletions.GetById(evt.ListId);

            if (completions == null)
            {
                completions = new TaskCompletions
                {
                    Id = evt.ListId,
                    TaskCompletion = new Dictionary<TodoText, DateTime>
                    {
                        [evt.Text] = DateTime.UtcNow
                    }
                };

                _taskCompletions.Insert(completions);
            }
            else
            {
                completions.TaskCompletion[evt.Text] = DateTime.UtcNow;

                _taskCompletions.Update(completions);
            }
        }

        [EventProcessor("042DAE97-3E59-4A7C-A995-022C65C21941")]
        public void Process(ItemNotDone evt)
        {
            var completions = _taskCompletions.GetById(evt.ListId);

            if (completions != null)
            {
                completions.TaskCompletion.Remove(evt.Text);

                _taskCompletions.Update(completions);
            }
        }
    }
}
