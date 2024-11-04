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
     * Complete the 'beautifulDays' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER i
     *  2. INTEGER j
     *  3. INTEGER k
     */

    public static int beautifulDays(int i, int j, int k)
    {
        List<string> listOfDaysAsStrings = new List<string>();
        List<int> listOfDaysAsIntegers = new List<int>();
        
        //Creating a list of the days as strings.
        //Also, creating a list of days as integers to use later.
        for(int m = i; m <= j; ++m){
            listOfDaysAsStrings.Add(m.ToString());
            listOfDaysAsIntegers.Add(m);
        }
        
        List<char[]> listOfCharArrays = new List<char[]>();
        
        //In order to reverse the strings, we must first convert it into a char array.
        //Creating a list of Char Arrays, where the revered char arrays are stored.
        foreach(string day in listOfDaysAsStrings){
            char[] charArray = day.ToCharArray();
            Array.Reverse(charArray);
            listOfCharArrays.Add(charArray);
        }
        
        List<int> reversedDays = new List<int>();
        
        //Converting each char array to a string and then converting it into an int.
        //Creating a list of integers to store the reveresed integers.
        foreach(char[] array in listOfCharArrays){
            string str = new string(array);
            int revrsedInt = int.Parse(str);
            reversedDays.Add(revrsedInt);
        }
        
        int beautifulDaysCounter = 0;
        
        for(int m = 0; m < reversedDays.Count; ++m){
            int difference = Math.Abs(listOfDaysAsIntegers[m] - reversedDays[m]);
            
            if(difference % k == 0){
                ++beautifulDaysCounter;
            }
            else{
                continue;
            }
        }
        
        return beautifulDaysCounter;
    
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int i = Convert.ToInt32(firstMultipleInput[0]);

        int j = Convert.ToInt32(firstMultipleInput[1]);

        int k = Convert.ToInt32(firstMultipleInput[2]);

        int result = Result.beautifulDays(i, j, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
