using System;
using System.Threading;

public delegate void Notifier(string message);

class MessageService
{
    public event Notifier NewMessage;

    public void Send(string message)
    {
        Console.WriteLine($"\n[Service] Надіслано: {message}");
        NewMessage?.Invoke(message);
    }
}

class Program
{
    static void Main()
    {
        var service = new MessageService();

        //Local_Method
        service.NewMessage += OnMessageReceived;

		static void OnMessageReceived(string message)
    {
        Console.WriteLine($"[Local_Method] Отримано: {message}");
    }
       
		//Anonym_Method
        service.NewMessage += delegate (string msg)
        {
            Console.WriteLine($"[Anonym_Method] Отримано: {msg}");
        };

       
		//Lambda_Method
        service.NewMessage += msg =>
            Console.WriteLine($"[Lambda_Method] Отримано: {msg}");

        service.Send("Привіт!");
        service.Send("Події працюють!");
	
		//Timer
		for(int i =1; i <=5; i++){
		Console.WriteLine("Надсилання повідомлень:");
			service.Send($"Повідомлення {i}");
			Thread.Sleep(300);
		}
    }   
}