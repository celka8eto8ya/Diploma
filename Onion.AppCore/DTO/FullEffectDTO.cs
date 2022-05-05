using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.DTO
{
    public class FullEffectDTO
    {
        public EffectDTO EffectDTO { get; set; }

        public double ROI_ExpensesAmount { get; set; }
        public double ROI_InvestmentsIncome { get; set; }
        public double ROI_InvestmentsAmount { get; set; }

        public double NPV_InitialInvestments { get; set; }
        public double NPV_DiscountRate { get; set; }
        public int NPV_YearsAmount { get; set; }
        public double [] NPV_CashFlows { get; set; }

        public double IRR_InitialInvestments { get; set; }
        public double IRR_DiscountRate { get; set; }
        public int IRR_YearsAmount { get; set; }
        public double[] IRR_CashFlows { get; set; }
    }
}
