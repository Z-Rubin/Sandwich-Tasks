using System;
using System.Collections.Generic;
using System.Linq;


class Simple_Calculator
{


    static char[] Add_Sub = { '+', '-' };
    static char[] Times_Div = { '*', '/' };



    static double Evaluate(string s)
    {
        return Split_Add_Sub(s);
    }

    static double Split_Add_Sub(string s)
    {
        string sub_s;
        string eval_string;
        string temp_s;
        double sum = 0;
        int pos = s.IndexOfAny(Add_Sub);

        if (pos == -1)
        {
            if (s.IndexOfAny(Times_Div) == -1)
            {
                sum = double.Parse(s);
            }
            else
            {
            sum = Solve_Times_Div(s);
            }
        }
        else
        {
            if (s.Substring(0,1).IndexOfAny(Add_Sub) == -1)
            {
                s = "+" + s;
            }

            while (s.Length > 0)
            {
                pos = s.Substring(1,s.Length-1).IndexOfAny(Add_Sub)+1;
                if (pos == 0)
                {
                    sub_s = s;
                    pos = s.Length;
                }
                else
                {
                    sub_s = s.Substring(0, pos);
                }

      

                eval_string = s.Substring(1, pos - 1);
                Console.WriteLine(eval_string);

                if (sub_s.IndexOfAny(Times_Div) == -1)
                {
                    if (sub_s[0] == '+')
                    {
                        sum += double.Parse(eval_string);
                    }
                    else
                    {
                        sum -= double.Parse(eval_string);
                    }
              
                }
                else
                {
                    if (sub_s[0] == '+')
                    {
                        sum += Solve_Times_Div(eval_string);
                    }
                    else
                    {
                        sum -= Solve_Times_Div(eval_string);
                    }
                  
                }
                s = s.Substring(pos);



            }
        }


        return sum;
    }
    static double Solve_Times_Div(string s)
    {
        double total = 0;
        int pos = s.IndexOfAny(Times_Div);


        total = double.Parse(s.Substring(0, pos));
        s = s.Substring(pos);


        while (Times_Div.Any(c => s.Contains(c))) {
            pos = s.IndexOfAny(Times_Div);

            if (s[pos] == '*')
            {
                s = s.Substring(pos+1);
                pos = s.IndexOfAny(Times_Div);
                if (pos != -1)
                {
                    total *= double.Parse(s.Substring(0, pos));
                } else
                {
                    total *= double.Parse(s);
                }
            }
            else
            {
                s = s.Substring(pos+1);
                pos = s.IndexOfAny(Times_Div);
                if (pos != -1)
                {
                    total /= double.Parse(s.Substring(0, pos));
                }
                else
                {
                    total /= double.Parse(s);
                }
 
            }
        }
        return total;
    }
    static void Main()
    {
        while (true)
        {
            string equation;
            Console.WriteLine("Input a mathematical equation to calculate:");
            
            equation  = Console.ReadLine();
            double output = Evaluate(equation);
            //double output = Solve_Times_Div(equation);
            Console.WriteLine("Result:");
            Console.WriteLine(output);
     



        }


    }


}