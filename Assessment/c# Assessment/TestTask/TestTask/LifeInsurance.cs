using System;

namespace TestTask
{
    internal class LifeInsurance : Insurance
    {
     
        private int policyTerm;
        private float benefitPercent;

      
        public int PolicyTerm
        {
            get { return policyTerm; }
            set { policyTerm = value; }
        }

        public float BenefitPercent
        {
            get { return benefitPercent; }
            set { benefitPercent = value; }
        }

        public LifeInsurance(string insuranceNo, string insuranceName, double amountCovered, int policyTerm, float benefitPercent)
            : base(insuranceNo, insuranceName, amountCovered)
        {
            PolicyTerm = policyTerm;
            BenefitPercent = benefitPercent;
        }

        public override double CalculatePremium()
        {
            return (AmountCovered - ((AmountCovered * BenefitPercent) /100)) / PolicyTerm;
        }
    }
}
