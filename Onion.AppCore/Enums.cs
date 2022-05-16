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
        public enum AccessLevels
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

        public enum OperationTypes
        {
            Create,
            Update,
            Delete,
            Open,
            Calculate
        }

        public enum ObjectNames
        {
            Customer,
            Project,
            DashBoard,
            Document,
            Effect,
            Team,
            Step,
            Task
        }
    }
}
