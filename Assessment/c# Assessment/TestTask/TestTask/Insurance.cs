using System;

namespace TestTask
{
    internal class Insurance
    {
       
        private string insuranceNo;
        private string insuranceName;
        private double amountCovered;

        public string InsuranceNo
        {
            get { return insuranceNo; }
            set { insuranceNo = value; }
        }

        public string InsuranceName
        {
            get { return insuranceName; }
            set { insuranceName = value; }
        }

        public double AmountCovered
        {
            get { return amountCovered; }
            set { amountCovered = value; }
        }

        public Insurance(string insuranceNo, string insuranceName, double amountCovered)
        {
            InsuranceNo = insuranceNo;
            InsuranceName = insuranceName;
            AmountCovered = amountCovered;
        }

    
        public virtual double CalculatePremium()
        {
            throw new NotImplementedException("CalculatePremium must be implemented in derived classes.");
        }
    }
}
