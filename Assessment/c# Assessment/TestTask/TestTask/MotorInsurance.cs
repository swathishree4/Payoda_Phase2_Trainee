using System;

namespace TestTask
{
    internal class MotorInsurance : Insurance
    {
        private double idv;
        private float depPercent;

       
        public double Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        public float DepPercent
        {
            get { return depPercent; }
            set { depPercent = value; }
        }

   
        public MotorInsurance(string insuranceNo, string insuranceName, double amountCovered, float depPercent)
            : base(insuranceNo, insuranceName, amountCovered)
        {
            DepPercent = depPercent;
        }

        
        public override double CalculatePremium()
        {
            Idv = AmountCovered - ((AmountCovered * DepPercent) / 100);
            return Idv * 0.03;
        }
    }
}
