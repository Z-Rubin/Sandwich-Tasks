using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


class Simple_Calculator
{


    static char[] Add_Sub = { '+', '-' };
    static char[] Times_Div = { '*', '/' };
    static char[] Brackets = { '(', ')' };



    static double Evaluate(string s)
    {
        double bracket_result;
        string innermost_bracket;

        s = RemoveSpaces(s);
        s = InsertTimes(s);


        if (s.IndexOfAny(Brackets) == -1) {
            return Split_Add_Sub(s);
        }
        while (s.IndexOfAny(Brackets) != -1)
        {
            innermost_bracket = FindInnermostBracketedPart(s);
            bracket_result = Split_Add_Sub(innermost_bracket);
           
            s = s.Replace("(" + innermost_bracket + ")", bracket_result.ToString());
        }
        return Split_Add_Sub(s);

    }

    static string RemoveSpaces(string input)
    {
        return input.Replace(" ", "");
    }

    static string FindInnermostBracketedPart(string equation)
    {
        Stack<int> stack = new Stack<int>();
        int start = -1;
        int end = -1;

        for (int i = 0; i < equation.Length; i++)
        {
            char ch = equation[i];

            if (ch == '(')
            {
                stack.Push(i);
            }
            else if (ch == ')')
            {
                if (stack.Count > 0)
                {
                    start = stack.Pop();
                    end = i;
                }
            }
        }
        string result = equation.Substring(start + 1, end - start - 1);
        if (result.IndexOfAny(Brackets) == -1)
        {
            return result;
        }
        else
        {
            return FindInnermostBracketedPart(result);
        }
    }

    static string InsertTimes(string s)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (i != 0)
            {
                if (s[i] == '(' && i + 1 < s.Length && Char.IsDigit(s[i - 1]))
                {
                    // Insert '*' before the opening bracket if the previous character is a digit
                    result.Append('*');
                }

                result.Append(s[i]);

                if (s[i] == ')' && i + 1 < s.Length && Char.IsDigit(s[i + 1]))
                {
                    // Insert '*' after the closing bracket if the next character is a digit and not at the end of the string
                    result.Append('*');
                }
            } else
            {
                result.Append(s[i]);
            }
        }

        return result.ToString();
    }

    static double Split_Add_Sub(string s)
    {
        string sub_s;
        string eval_string;
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
            if (IsValidEquation(equation))
            {
                double output = Evaluate(equation);
                Console.WriteLine("Result:");
                Console.WriteLine(output);
            } else
            {
                Console.WriteLine("The equation you have entered is not a valid equation. Please try again. \n");
            }
     



        }


    }
    static bool IsValidEquation(string equation)
    {
        try
        {
            DataTable table = new DataTable();
            double result = Convert.ToDouble(table.Compute(equation, string.Empty));
            return true;
        }
        catch
        {
            return false;
        }
    }


}