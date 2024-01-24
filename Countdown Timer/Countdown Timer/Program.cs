using System;
using System.Threading;
using System.Timers;



class Countdown_Timer
{
    static int counts_left;
    static System.Timers.Timer countdownTimer;
    static ManualResetEvent countdownCompleteEvent = new ManualResetEvent(false);


    static void Countdown_Sleep(int N, int step)
    {
        for (int i = N; i >= 0; i -= step)
        {
            Console.WriteLine(i);
            if (N != 0)
            {
                Thread.Sleep(step * 1000);
            }

        }
    }
    static void Initialize_timer(int N, int step)
    {
        // Create a timer with the specified step
        countdownTimer = new System.Timers.Timer(step * 1000); 

        countdownTimer.Elapsed += CountdownTimerElapsed;

        counts_left = N / step;

        countdownTimer.Start();
    }

    static void CountdownTimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine(counts_left);
        if (--counts_left == -1)
        {
            countdownTimer.Stop();    

            // Exit the application
            countdownCompleteEvent.Set();
        }
    }
    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Timer elapsed at: " + e.SignalTime);
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

            Console.WriteLine("Which timer would you like to use. Type 1 for sleep and type 2 for timer object.");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                Countdown_Sleep(N, Step);
            }
            else
            {
                Initialize_timer(N, Step);
                countdownCompleteEvent.WaitOne();

            }
        }
        catch
        {
            Console.WriteLine("Input must be an integer. Close the program and try again.");

        }

    }
}