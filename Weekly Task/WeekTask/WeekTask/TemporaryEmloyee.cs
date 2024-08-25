using System;

public class TemporaryEmloyee : Employee
{
    public int dailywages { set; get; }
    public int noofdays { set; get; }

    public TemporaryEmloyee(int id,string name,int  dailywages,int noofdays)
    {
        this.id = id;
        this.name = name;   
        this.dailywages = dailywages;   
        this.noofdays = noofdays;
    }
    public override float CalculateSalary(int id, string name, float basicsalary)
    {
        netsalary = dailywages * noofdays;
        return netsalary;
    }
    public override float CalculateBonus(float salary, int criteria)
    {
        if (salary < 1000)
        {
            bonus = netsalary * 0.15F;
        }
        else if(salary >=1000 && salary < 1500)
        {
            bonus = netsalary * 0.12F;

        }
        else if(salary >=1500 &&  salary < 1750)
        {
            bonus = netsalary * 0.11F;
        }
        else if (salary >= 1750)
        {
            bonus = netsalary * 0.8F;
        }
        return bonus;
    }
}
