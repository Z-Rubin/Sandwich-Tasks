using System;
using System.Threading;
using System.Timers;



class Countdown_Timer
{
    public static int pub_step;
    static int time_left;
    static System.Timers.Timer countdownTimer;
    static ManualResetEvent countdownCompleteEvent = new ManualResetEvent(false);


    static void Countdown_Sleep(int N, int step)
    {
        for (int i = N; i >= 0; i -= step)
        {
            Console.WriteLine(time_left);
            if (N != 0)
            {
                if (time_left > step)
                {
                    Thread.Sleep(step * 1000);
                    time_left -= step;

                }
                else
                {
                    Thread.Sleep(time_left * 1000);
                    time_left = 0;
                    Console.WriteLine(time_left);
                }
            }

        }
    }
    static void Initialize_timer(int N, int step)
    {
        // Create a timer with the specified step
        countdownTimer = new System.Timers.Timer(step * 1000); 

        countdownTimer.Elapsed += CountdownTimerElapsed;

        Console.WriteLine(time_left);


        countdownTimer.Start();
    }

    static void CountdownTimerElapsed(object sender, ElapsedEventArgs e)
    {
        time_left -= pub_step;
        if (time_left >= 0) {
            Console.WriteLine(time_left);
        }
        else
        {
            Console.WriteLine(0);

        }
        if (time_left < pub_step && time_left > 0)
        {
            countdownTimer.Interval = time_left * 1000;
        }
        if (time_left <= 0)
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