using System;
using System.Collections.Generic;
using System.Linq;


record Student(int Id, string Name, string Group, int Avg, bool IsActive, string Email);
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("\n===Task1: Students_Analytics===");
	 var students = new List<Student>
        {
            new(1, "Анна",   "A-01", 85, true,  "anna@mail.com"),
            new(2, "Богдан", "A-01", 78, true,  "bogdan@mail.com"),
            new(3, "Віктор", "A-02", 92, true,  "viktor@mail.com"),
            new(4, "Ганна",  "A-02", 88, false, "hanna@mail.com"),
            new(5, "Дмитро", "A-03", 81, true,  "dmytro@mail.com"),
            new(6, "Ірина",  "A-03", 95, true,  "iryna@mail.com"),
            new(7, "Максим", "A-01", 67, false, "maksym@mail.com"),
            new(8, "Олена",  "A-02", 90, true,  "olena@mail.com"),
            new(9, "Павло",  "A-03", 73, true,  "pavlo@mail.com")
        };
	
	var ActiveStudents = 
		from s in students
		group s by s.Group into g
		select new
	{
		Group = g.Key,
		Count = g.Count(),
		AvgGroup = Math.Round(g.Average(x => x.Avg), 2) 
	};
		var ActiveStudents_List = ActiveStudents
		.OrderByDescending(g => g.AvgGroup)
    .ToList(); 
		foreach (var g in ActiveStudents_List)
        {
            Console.WriteLine($"Група: {g.Group}, Кількість: {g.Count}, Середній бал: {g.AvgGroup}");
	}
}
}