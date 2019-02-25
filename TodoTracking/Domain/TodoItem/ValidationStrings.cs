namespace Domain.TodoItem
{
    public static class ValidationStrings
    {
        internal static string ListDoesNotExist = "That list does not exist";
        internal static string RuleDoesNotExistOnTheList = "That list does not have that task";
        internal static string TaskIsAlreadyDone = "The task is already done";
        internal static string TaskIsNotDone = "The task is not done";
        internal static string ListIdMustBeSet = "The list id must be set";
        internal static string TaskMustBeRecentlyDone = "The task can only be undone for 24 hours";
    }
}
