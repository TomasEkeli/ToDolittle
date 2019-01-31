using System;
using System.Linq;
using Concepts.TodoItem;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.TodoItem;

namespace Read.TodoItem
{
    public class ItemListProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<AvailableLists> _repositoryForAvailableLists;

        public ItemListProcessor(
            IReadModelRepositoryFor<AvailableLists> repositoryForAvailableLists            
        )
        {
            _repositoryForAvailableLists = repositoryForAvailableLists;
        }
        
        [EventProcessor("eac6222e-1e7e-0fe2-2213-2715c8ebffce")]
        public void Process(ItemCreated evt)
        { 
            var allLists = _repositoryForAvailableLists.GetById(default(Guid));

            if (allLists != null)
            {
                if (!allLists.Lists.Any(list => list == evt.ListId))
                {
                    allLists.Lists.Add(evt.ListId);
                    _repositoryForAvailableLists.Update(allLists);
                }
            }
            else 
            {
                allLists = new AvailableLists
                {
                    Id = default(Guid),
                    Lists = new ListId[]
                    {
                        evt.ListId
                    }
                };

                _repositoryForAvailableLists.Insert(allLists);
            }
        }

        [EventProcessor("25583425-CC44-4EDD-ABA5-337418EE7FB9")]
        public void Process(ListDeleted evt)
        {
            var allLists = _repositoryForAvailableLists.GetById(default(Guid));

            if (allLists != null) 
            {
                allLists.Lists = 
                    allLists
                        .Lists
                        .Where(list => list != evt.ListId)
                        .ToList();

                _repositoryForAvailableLists.Update(allLists);
            }
        }
    }
}
