using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.TodoItem
{
    public class AllAvailableLists : IQueryFor<AvailableLists>
    {
        readonly IReadModelRepositoryFor<AvailableLists> _repositoryForAvailableLists;

        public AllAvailableLists(IReadModelRepositoryFor<AvailableLists> repositoryForAvailableLists)
        {
            _repositoryForAvailableLists = repositoryForAvailableLists;
        }

        public IQueryable<AvailableLists> Query => _repositoryForAvailableLists.Query;
    }
}
