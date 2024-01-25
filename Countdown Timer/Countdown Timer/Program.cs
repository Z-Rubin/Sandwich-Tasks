using System;
using System.Threading;
using System.Timers;



class Countdown_Timer
{
    public static int pub_step;
    static int counts_left;
    static int time_left;
    static System.Timers.Timer countdownTimer;
    static ManualResetEvent countdownCompleteEvent = new ManualResetEvent(false);


    static void Countdown_Sleep(int N, int step)
    {
        for (int i = N; i >= 0; i -= step)
        {
            Console.WriteLine(i);
            if (N != 0)
            {
                if (time_left > step)
                {
                    Thread.Sleep(step * 1000);
                } else
                {
                    Console.WriteLine(time_left + "hello");
                    Thread.Sleep(time_left * 1000);
                }
            }
            time_left -= N;

        }
    }
    static void Initialize_timer(int N, int step)
    {
        // Create a timer with the specified step
        countdownTimer = new System.Timers.Timer(step * 1000); 

        countdownTimer.Elapsed += CountdownTimerElapsed;

        counts_left = N / step;
        Console.WriteLine(counts_left * pub_step);
        counts_left -= 1;


        countdownTimer.Start();
    }

    static void CountdownTimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine(counts_left*pub_step);
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
            time_left = N;
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
                pub_step = Step;
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