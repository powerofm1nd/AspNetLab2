namespace WebApplication2.Model;

public class Company
{
    public string Name { get; set; }
    public uint Employees { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Employees: {Employees}";
    }

    public Company(string name, uint employees)
    {
        Name = name;
        Employees = employees;
    }
}