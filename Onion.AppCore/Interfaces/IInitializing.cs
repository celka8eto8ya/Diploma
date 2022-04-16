namespace Onion.AppCore.Interfaces
{
    public interface IInitializing
    {
        void InitializeRoles();
        void InitializeEmployee();
        void InitializeConditions();
        void InitializeReviewStages();
        void Initialize();
    }
}
