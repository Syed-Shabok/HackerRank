using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'findDigits' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int findDigits(int n)
    {
        List<int> dights = new List<int>();
        //Converting n to string to find number of digits in n easily. 
        string str = n.ToString();
        int counter = 0;
        
        //Putting each digit in n into a list. 
        foreach(char c in str){
            dights.Add(int.Parse(c.ToString()));
        }
        
        foreach(int digit in dights){
            if(digit == 0){
                continue;
            }
            else if(n % digit == 0){
                ++counter;
            }
        }
        
        return counter;        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.findDigits(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
