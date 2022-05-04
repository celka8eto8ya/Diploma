using System;

namespace Onion.AppCore.DTO
{
    public class EffectDTO
    {
        public int Id { get; set; }
        public DateTime CalculateDate { get; set; }
        public double IRR { get; set; }
        public double ROI { get; set; }
        public double NPV { get; set; }
        public double ETC { get; set; } // (Employees Time Cost)
        public double PCT_A { get; set; } // (Percent Compelition Tasks – Amount)
        public double PCT_T { get; set; } // (Percent Compelition Tasks – Time)
        public double POT { get; set; } // (Percent Overdue Time)
        public double POA { get; set; } // (Percent Overdue Amount)


        public int ProjectId { get; set; }
    }
}
