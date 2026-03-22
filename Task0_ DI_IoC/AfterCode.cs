// See https://aka.ms/new-console-template for more information

using System; 
using System.Collections.Generic;

public interface IRepo
{
    List<string> GetData(); 
    
}
public class Repo : IRepo
{
    public List<string> GetData()
    {
        return new List<string> { "item1", "item2", "item3" };
    }
}
public class Service
{
    private readonly IRepo _repo;

    public Service(IRepo repo)
    {
        _repo = repo;
    }

    public string Execute()
    {
        var data = _repo.GetData();
        return $"Processed {data.Count} items";
    }
}
public class Program
{
    public static void Main()
    {
        IRepo repo = new Repo();
        var service = new Service(repo);

        Console.WriteLine(service.Execute());
    }
}