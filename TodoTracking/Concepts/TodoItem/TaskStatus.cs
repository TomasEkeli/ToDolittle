using System;
using Dolittle.Concepts;

namespace Concepts.TodoItem
{
    public class TaskStatus : ConceptAs<string>
    {
        const string _done = "done";
        const string _not_done = "not done";
        const string _unknown = "unknown status";
        public static readonly TaskStatus Done = new TaskStatus { Value = _done };
        public static readonly TaskStatus NotDone = new TaskStatus { Value = _not_done };
        public static readonly TaskStatus Unknown = new TaskStatus { Value = _unknown };
    
        public static implicit operator TaskStatus(string value)
        {
            if (_done.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return Done;
            }
            if (_not_done.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return NotDone;
            }
            return Unknown;
        }
    }
}
