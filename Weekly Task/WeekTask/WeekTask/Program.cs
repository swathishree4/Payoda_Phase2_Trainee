// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter the details");
Console.WriteLine("Enter the type of Employee:");
string type=Console.ReadLine();
if (type.ToLower().Equals("permanent"))
{
    Console.WriteLine("Employee Id:");
    int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Employee Name:");
    string name=Console.ReadLine();
    Console.WriteLine("Basic salary");
    float salary=Convert.ToSingle(Console.ReadLine());
    Console.WriteLine("PF");
    int pf=Convert.ToInt32(Console.ReadLine());
    PermanentEmployee obj=new PermanentEmployee(id,name,salary,pf);
    obj.CalculateSalary(id, name, salary);
    obj.CalculateBonus(salary, pf);
    Console.WriteLine("The details are:");
    Console.WriteLine("Employee Id:" + obj.id);
    Console.WriteLine("Employee Name:" + obj.name);
    Console.WriteLine("Basic salary:"+obj.basicsalary);
    Console.WriteLine("PF:"+obj.pf);
    Console.WriteLine("Bonus:" + obj.bonus);
    Console.WriteLine("Net Salary:" + obj.netsalary);
}
else if (type.ToLower().Equals("temporary"))
{

    Console.WriteLine("Employee Id:");
    int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Employee Name:");
    string name = Console.ReadLine();
    Console.WriteLine("Daily Wages:");
    int wage=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("No.of days worked:");
    int days = Convert.ToInt32(Console.ReadLine());
    TemporaryEmloyee obj1 = new TemporaryEmloyee(id,name,wage,days);
    
    obj1.CalculateSalary(id, name, wage);
    obj1.CalculateBonus(wage, days);
    Console.WriteLine("Employee Id:" + obj1.id);
    Console.WriteLine("Employee Name:" + obj1.name);
    Console.WriteLine("Daily Wages:" + obj1.dailywages);
    Console.WriteLine("No.of days worked:" + obj1.noofdays);
    Console.WriteLine("Bonus:" + obj1.bonus);
    Console.WriteLine("Net Salary:" + obj1.netsalary);


}
