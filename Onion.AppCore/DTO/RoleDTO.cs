using System;

namespace Onion.AppCore.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
