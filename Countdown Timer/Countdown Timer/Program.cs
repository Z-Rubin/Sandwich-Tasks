using System;
using System.Threading;


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

    static void Main()
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

}