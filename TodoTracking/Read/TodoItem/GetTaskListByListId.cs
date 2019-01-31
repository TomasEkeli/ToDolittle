using System;
using System.Linq;
using Concepts.TodoItem;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.TodoItem
{
    public class GetTaskListByListId : IQueryFor<TaskList>
    {
        readonly IReadModelRepositoryFor<TaskList> _repositoryForTaskList;

        public ListId ListId { get; set; } = ListId.None;

        public GetTaskListByListId(IReadModelRepositoryFor<TaskList> repositoryForTaskList)
        {
            _repositoryForTaskList = repositoryForTaskList;
        }

        public IQueryable<TaskList> Query
        {
            get
            {
                return ListId == ListId.None 
                    ? new TaskList[0].AsQueryable()
                    : new [] 
                    {
                        _repositoryForTaskList
                            .Query
                            .FirstOrDefault(readModel => readModel.Id == ListId)
                    }.AsQueryable();
            }
        }
    }
}
