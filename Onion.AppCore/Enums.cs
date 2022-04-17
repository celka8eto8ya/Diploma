namespace Onion.AppCore
{
    public class Enums
    {
        public enum Roles
        {
            ProjectManager,
            Employee,
            Customer,
            Admin
        }
       public enum  AccessLevels
        {
            Low,
            Medium, 
            High,
            Setting
        }

        public enum Conditions
        {
            Completed,
            ForImplementation, 
            InProgress, 
            ForConsideration
        }

        public enum ReviewStages
        {
            Accepted, 
            ForRevision, 
            ForConsideration, 
            None
        }
    }
}
