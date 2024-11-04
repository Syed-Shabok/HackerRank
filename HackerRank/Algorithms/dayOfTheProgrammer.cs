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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static bool isLeapYear(int year){
        if(year % 400 == 0){
            return true;
        }
        else if(year % 4 ==0){
            if(year % 100 == 0){
                return false;
            }
            else{
                return true;
            }
        }
        return false;
    }
    
    public static string dayOfProgrammer(int year)
    {
        string result = "";
        
        if(year == 1918){
            //Console.WriteLine("Transitional year");
            result = "26.09." + year;
        }
        
        else if(year >= 1700 && year <= 1917){
            
            if(year % 4 == 0){
                //Console.WriteLine("Julian leap year");
                result = "12.09." + year;
            }
            else{
                //Console.WriteLine("Julian common year");
                result = "13.09." + year;
            }    
        }
        
        else{
            if(isLeapYear(year)){
                //Console.WriteLine("Gregorian leap year");
                result = "12.09." + year;
            }
            else{
                //Console.WriteLine("Gregorian common year");
                result = "13.09." + year;
            }
        }
        
        return result;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
