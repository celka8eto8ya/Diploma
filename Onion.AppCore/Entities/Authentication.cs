namespace Onion.AppCore.Entities
{
    public class Authentication
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public int EmployeeId { get; set; } // foreign key
        public Employee Employee { get; set; } // navigation property
    }
}
