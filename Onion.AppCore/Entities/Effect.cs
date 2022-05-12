using System;

namespace Onion.AppCore.Entities
{
   public class Effect
    {
        public int Id { get; set; }
        public DateTime CalculateDate { get; set; }
        public double IRR { get; set; }
        public double ROI { get; set; }
        public double NPV { get; set; }
        public double ETC { get; set; } // (Employees Time Cost)
        public double CT_T { get; set; } // (Compelition Tasks – Time)
        public double PCT_T { get; set; } // (Percent Compelition Tasks – Time)
        public double POT { get; set; } // (Percent Overdue Time)
        public double OT { get; set; } // (Overdue Amount)

        public double ROI_ExpensesAmount { get; set; }
        public double ROI_InvestmentsIncome { get; set; }
        public double ROI_InvestmentsAmount { get; set; }

        public double NPV_InitialInvestments { get; set; }
        public double NPV_DiscountRate { get; set; }
        public int NPV_YearsAmount { get; set; }
        public string NPV_CashFlows { get; set; }

        public double IRR_InitialInvestments { get; set; }
        public double IRR_DiscountRate { get; set; }
        public int IRR_YearsAmount { get; set; }
        public string IRR_CashFlows { get; set; }


        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
    }
}
