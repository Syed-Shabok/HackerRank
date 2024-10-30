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
     * Complete the 'permutationEquation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY p as parameter.
     */

    public static List<int> permutationEquation(List<int> p)
    {
        int n = p.Count;
        List<int> tempOne = new List<int>();
        
        for(int i = 1; i <= n; ++i){
            int temp = p.IndexOf(i) + 1;
            tempOne.Add(temp);
            //Console.WriteLine($"{i} number element in t1 = {temp}");
        }
        
        List<int> tempTwo = new List<int>();
        
        for(int i = 0; i < tempOne.Count; ++i){
            int temp = p.IndexOf(tempOne[i]) + 1;
            tempTwo.Add(temp);
            //Console.WriteLine($"{i+1} number element in t2 = {temp}");
        }
        
        return tempTwo;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> p = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt32(pTemp)).ToList();

        List<int> result = Result.permutationEquation(p);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
