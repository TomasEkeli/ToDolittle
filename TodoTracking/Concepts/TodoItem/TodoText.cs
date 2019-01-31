using Dolittle.Concepts;

namespace Concepts.TodoItem
{
    public class TodoText : ConceptAs<string>
    {
        public static implicit operator TodoText(string value)
        {
            return new TodoText {Value = value};
        }
    }
}
