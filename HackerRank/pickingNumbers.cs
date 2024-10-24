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
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int pickingNumbers(List<int> a)
    {
            int length = a.Count;
            List<int> subArray = new List<int>();
            int maxLength = 0;
            
            for(int i = 0; i < length; ++i){
                subArray.Add(a[i]);
                for(int j = i + 1; j < length; ++j){
                    if(Math.Abs(a[i] - a[j]) <= 1){
                        subArray.Add(a[j]);
                    }
                }
                //It is possible that after the nested for loop runs, there will
                //be elements that have an abs.difference thst is >1. 
                //In perticular, this differnce will always be between 
                //the highest and lowest elements. 
                int minVal = subArray.Min();
                int maxVal = subArray.Max();
                if(Math.Abs(minVal - maxVal) > 1){
                    subArray.RemoveAll(x => x == maxVal);
                }
                
                if(subArray.Count > maxLength){
                    maxLength = subArray.Count;
                }
                subArray.Clear();
            }
            
            return maxLength;       
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
