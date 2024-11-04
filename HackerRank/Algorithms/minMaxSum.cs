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
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        int n = arr.Count;
        List<long> myList = new List<long> (n);
        
        for(int i = 0; i < n; ++i){
            long sum = 0;
            for(int j = 0; j < n; ++j){
                if(j != i){
                    sum += arr[j];
                }
            }
            myList.Add(sum);
        }
        
        long maxValue = myList.Max();
        long minValue = myList.Min();
        
        Console.WriteLine($"{minValue} {maxValue}");
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
