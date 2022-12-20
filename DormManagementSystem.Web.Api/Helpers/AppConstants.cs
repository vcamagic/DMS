namespace DormManagementSystem.Web.Api.Helpers;

public static class AppConstants
{
    public static class AppRoles 
    {
        public const string Warden = "warden";
        public const string Administrator = "administrator";
        public const string Maid = "maid";
        public const string Doorkeeper = "doorkeeper";
        public const string Student = "student";
        public const string Janitor = "janitor";
    }

    public static class AppPolicies
    {
        public const string WardenPolicy = "WardenPolicy";
        public const string AdministratorPolicy = "AdministratorPolicy";
        public const string MaidPolicy = "MaidPolicy";
        public const string DoorkeeperPolicy = "DoorkeeperPolicy";
        public const string StudentPolicy = "StudentPolicy";
        public const string JanitorPolicy = "JanitorPolicy";
    }
}
