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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        int n = arr[0].Count;
        int leftToRightDiagonalSum = 0;
        // variable x used to access the left to right diagonal elements 
        //(0,0), (1,1), (2,2), ... 
        int x = 0; 
        for(int i = 0; i < n; ++i){
            leftToRightDiagonalSum += arr[x][x];
            ++x;
        }
        
        int rightToLeftDiagonalSum = 0;
        // variable x used to access the left to right diagonal elements 
        //(0,2), (1,1), (2,0), ... 
        int y = 0;
        int z = n-1;
        for(int i =0; i < n; ++i){
            rightToLeftDiagonalSum += arr[y][z];
            ++y;
            --z;
        }
        
        return Math.Abs(leftToRightDiagonalSum - rightToLeftDiagonalSum);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
