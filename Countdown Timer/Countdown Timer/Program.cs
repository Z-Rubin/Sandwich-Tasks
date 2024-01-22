using System;
using System.Threading;
using System.Timers;



class Countdown_Timer
{

    static void Countdown_Sleep (int N, int step)
    {
        for (int i = N; i >= 0; i-=step)
        {
            Console.WriteLine(i);
            if (N != 0)
            {
                Thread.Sleep(step * 1000);
            }

        }
    }

    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Timer elapsed at: " + e.SignalTime);
    }
    static void use_countdown_timer()
    {
        Console.WriteLine("Input an integer to count down from:");
        string sN = Console.ReadLine();
        try
        {
            int N = int.Parse(sN);

            Console.WriteLine("Input an integer for step size:");

            string sStep = Console.ReadLine();
            int Step = int.Parse(sStep);

            System.Timers.Timer timer = new System.Timers.Timer(Step*1000);

     
        }
        catch
        {
            Console.WriteLine("Input must be an integer. Close the program and try again.");

        }
    }

    static void use_countdown_sleep()
    {
        Console.WriteLine("Input an integer to count down from:");
        string sN = Console.ReadLine();
        try
        {
            int N = int.Parse(sN);

            Console.WriteLine("Input an integer for step size:");
            string sStep = Console.ReadLine();
            int Step = int.Parse(sStep);
            Countdown_Sleep(N, Step);
        }
        catch
        {
            Console.WriteLine("Input must be an integer. Close the program and try again.");

        }
    }

    static void Main()
    {
        use_countdown_timer();        
    }

}