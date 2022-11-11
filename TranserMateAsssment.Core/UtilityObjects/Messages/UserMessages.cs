namespace TranserMateAsssment.Core.Messages
{
    public class UserMessages
    {
        public static string NoTaskFound
        {
            get { return "No Tasks Found"; }
        }
        public static string InternalServerError
        {
            get { return "Something went wrong,Please try again"; }
        }
        public static string InputValidationError
        {
            get { return "Please give valid Input"; }
        }
        public static string DuplicateTaskError
        {
            get { return "Another task with same name is already exist"; }
        }
    }
}