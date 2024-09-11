using System;
using TestTask;

namespace TestTask
{
    class Program
    {
        public static void Main(string[] args)
        {
          
            Console.WriteLine("Insurance Number:");
            string i_no = Console.ReadLine();

            Console.WriteLine("Insurance Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Amount Covered:");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select");
            Console.WriteLine("1. Life Insurance");
            Console.WriteLine("2. Motor Insurance");

            int opt = Convert.ToInt32(Console.ReadLine());

            Insurance insurance;

            if (opt == 1)
            {
                Console.WriteLine("Policy Term:");
                int policyTerm = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Benefit Percent:");
                float benefitPercent = Convert.ToSingle(Console.ReadLine());

                insurance = new LifeInsurance(i_no, name, amount, policyTerm, benefitPercent);
            }
            else if (opt == 2)
            {
                Console.WriteLine("Depreciation Percent:");
                float depPercent = Convert.ToSingle(Console.ReadLine());

                insurance = new MotorInsurance(i_no, name, amount, depPercent);
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
                return;
            }

            double premium = AddPolicy(insurance, opt);
            Console.WriteLine("Calculated Premium: " + premium);
        }

        public static double AddPolicy(Insurance ins, int opt)
        {
            if (opt == 1)
            {
                LifeInsurance life = (LifeInsurance)ins;
                return life.CalculatePremium();
            }
            else if (opt == 2)
            {
                MotorInsurance mlife = (MotorInsurance)ins;
                return mlife.CalculatePremium();
            }
            else
            {
                return 0;
            }
            
        }
    }
}
