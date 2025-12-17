using System;
using System.Reflection;


public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    
    public void PrintInfo()
    {
        Console.WriteLine($"{Name}, {Age}, group {Group}");
    }
}

class Program{
  
static void Main(){

Type studentType = typeof(Student);

Console.WriteLine("Властивості класу Student:");

foreach (PropertyInfo property in studentType.GetProperties())
{
    Console.WriteLine($"- {property.Name}: {property.PropertyType.Name}");
    
}

foreach (MethodInfo method in studentType.GetMethods())
{
    Console.WriteLine($"- {method.Name}");
}
 }
}