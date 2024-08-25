using System;

public abstract class Employee
{
    public int id { set; get; }
    public string name { set; get; }
    public float basicsalary { set; get; }
    public float bonus { set; get; }
    public float netsalary { set; get; }
    public abstract float CalculateSalary(int id,string name,float basicsalary);
	public abstract float CalculateBonus(float salary, int criteria);
	

}
