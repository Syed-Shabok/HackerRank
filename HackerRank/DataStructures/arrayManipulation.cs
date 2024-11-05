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
     * Complete the 'arrayManipulation' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        List<long> listOfZeros = new List<long>();
        for(int i = 0; i < n; ++i){
            listOfZeros.Add(0);
        }
        
        //Using Prefix Sum method to avoid high  time complexiy.
         
        for(int i = 0; i < queries.Count; ++i){
            int a = queries[i][0];
            int b = queries[i][1];
            int k = queries[i][2];
            
            listOfZeros[a - 1] += k;
            if(((b - 1) + 1) < n){
                listOfZeros[(b - 1) + 1] -= k;   
            }  
        }
        
        long maxSum = 0;
        long currentSum = 0;
        for(int i = 0; i < n; ++i){
            currentSum += listOfZeros[i];
            if(currentSum > maxSum){
                maxSum = currentSum;
            }
        }
        
        return maxSum;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        long result = Result.arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
