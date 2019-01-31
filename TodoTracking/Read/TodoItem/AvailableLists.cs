using System;
using System.Collections.Generic;
using Concepts.TodoItem;
using Dolittle.ReadModels;

namespace Read.TodoItem
{
    public class AvailableLists : IReadModel
    {
        public Guid Id { get; set; }
        public IList<ListId> Lists { get; set; }
    }
}
