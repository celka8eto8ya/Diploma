namespace Onion.AppCore
{
    public class Enums
    {
        public enum Roles
        {
            ProjectManager,
            Employee,
            Customer
        }
       public enum  AccessLevels
        {
            Low,
            Medium, 
            High
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
