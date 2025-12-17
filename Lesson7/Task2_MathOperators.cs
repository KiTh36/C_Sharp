using System;
using System.Reflection;

public class MathOperations
{
    public int Add(int a, int b) => a + b;
    public int Sub(int a, int b) => a - b;
    public int Mul(int a, int b) => a * b;
    public int Div(int a, int b) => a / b;
}


class Program{
  static void Main(){
    var math = new MathOperations();
    
    Type type = typeof(MathOperations);
    MethodInfo addMethod = type.GetMethod("Add");
    
    Console.Write("Input the name of the method you want: (Add, Sub, Mul, Div): ");
        string methodName = Console.ReadLine();
        
        MethodInfo method = type.GetMethod(methodName);
        
        if(method != null){
         object result = method.Invoke(math, new object[] { 5, 10 }); 
         Console.WriteLine($"{methodName}(5, 10) = {result}");
        }
    
    else
        {
            Console.WriteLine("Метод не найден!");
        }
  }
}