using System;

public class PermanentEmployee : Employee
{
	public int pf {  get; set; }
    

    public PermanentEmployee(int id,string name,float basicsalary,int pf)
    {
        this.id = id;
        this.name = name;
        this.pf = pf;
        this.basicsalary = basicsalary;
    }

    public override  float CalculateSalary(int id, string name, float basicsalary)
    {

        netsalary = basicsalary - pf;


        return netsalary;
    }
    public override float CalculateBonus(float salary, int criteria)
    {
        if (pf < 1000)
        {
            bonus = (float)(basicsalary * 0.10) ;
        }
        else if (pf >= 1000 && pf < 1500)
        {
            bonus = (float)(basicsalary * 0.115);
        }
        else if (pf >= 1500 && pf < 1800)
        {
            bonus = (float)(basicsalary * 0.12);
        }
        else if(pf >= 1800)
        {
            bonus = (float)(basicsalary * 0.15);
        }

        return bonus;
    }

}
