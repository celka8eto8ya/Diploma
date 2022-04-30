using System;

namespace Onion.AppCore.DTO
{
    public class FullDashBoardDTO
    {
        public int Id { get; set; }
        public DateTime SetDate { get; set; }
        public string Employee { get; set; }
        public string Team { get; set; }
        public string Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
