namespace Market.Web
{
    public class WebConstants
    {
        public const string TempDataErrorMessageKey = "ErrorMessage";
        public const string TempDataSuccessMessageKey = "SuccessMessage";

        //Roles
        public const string AdministratorRole = "Administrator";

        //Areas
        public const string AdminArea = "Admin";
        public const string PostArea = "Post";
        public const string UserArea = "User";
        public const string CommunicationArea = "Communication";

        //User account edit
        public const string FirstNameChanged = "Changed First Name";
        public const string MiddleNameChanged = "Changed Middle Name";
        public const string LastNameChanged = "Changed Last Name";
        public const string BirthDateChange = "Changed Birthdate";
        public const string PasswordChanged = "Changed Password";
        public const string EmailChanged = "Changed Email";
        public const string ProfilePictureChange = "Changed Profile Picture";

        //User activity
        public const string SawPost = "Saw post {0}"; //Id
        public const string AddedPost = "Added new post {0}";
        public const string DeletedPost = "Deleted post {0}";
        public const string UpdatedPost = "Updated post {0}";
        public const string SentMessage = "Sent message to {0}"; //UserName
        public const string SawProfile = "Saw {0}'s profile";
        public const string SearchedFor = "Searched for {0}";
    }
}
