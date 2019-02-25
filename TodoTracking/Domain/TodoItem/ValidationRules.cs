using Concepts.TodoItem;

namespace Domain.TodoItem
{
    public delegate bool MustBeAnExistingList(ListId list);
    public delegate bool MustBeATaskOnTheList(ListId list, TodoText text);
    public delegate bool MustNotBeATaskOnTheList(ListId list, TodoText text);
    public delegate bool MustBeDoneOnTheList(ListId list, TodoText text);
    public delegate bool MustNotBeDoneOnTheList(ListId list, TodoText text);
    public delegate bool MustBeDoneRecently(ListId list, TodoText text);
}