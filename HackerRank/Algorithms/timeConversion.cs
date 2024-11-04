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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        string firstTwoDights = s[0].ToString() + s[1].ToString();
        int digits = int.Parse(firstTwoDights);
        string str = "";
        
        if(s[8] == 'P'){
            if(digits != 12){
                digits += 12;
            }
            str += digits.ToString();
            str += s.Substring(2,6);
        }
        else{
            if(digits == 12){
                firstTwoDights = "00";
            }
            str +=firstTwoDights;
            str += s.Substring(2,6);
        }
        
        return str;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
