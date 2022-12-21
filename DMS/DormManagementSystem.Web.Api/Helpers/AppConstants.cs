namespace DormManagementSystem.Web.Api.Helpers;

public static class AppConstants
{
    public static class AppRoles 
    {
        public const string Warden = "Warden";
        public const string Administrator = "Administrator";
        public const string Maid = "Maid";
        public const string Doorkeeper = "Doorkeeper";
        public const string Student = "Student";
        public const string Janitor = "Janitor";
    }

    public static class AppPolicies
    {
        public const string WardenPolicy = "WardenPolicy";
        public const string AdministratorPolicy = "AdministratorPolicy";
        public const string MaidPolicy = "MaidPolicy";
        public const string DoorkeeperPolicy = "DoorkeeperPolicy";
        public const string StudentPolicy = "StudentPolicy";
        public const string JanitorPolicy = "JanitorPolicy";
        public const string OwnsAccountPolicy = "OwnsAccountPolicy";
    }
}
