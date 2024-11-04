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
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */
         
    public static List<List<int>> ExtractSubList(List<List<int>> original, int startRow, int startCol, int numRows, int numCols){
        
        List<List<int>> result = new List<List<int>>();
        
        for(int i = 0; i < numRows; ++i){
            List<int> row = new List<int>();
            for(int j = 0; j < numCols; ++j){
                row.Add(original[startRow +i][startCol +j]);
            }
            result.Add(row);
        }
        
        return result;
    }
    
     public static int giveSum(List<List<int>> someArr){
        
        int sum = 0;
        
        for(int i = 0; i < someArr.Count; ++i){
            for(int j = 0; j < someArr[i].Count; ++j){
                if((i == 1 && j == 0) || (i == 1 && j == 2)){
                    continue;
                }
                else{
                    sum += someArr[i][j];   
                }
            }
        }
        
        return sum;
    }
        
    
    public static int hourglassSum(List<List<int>> arr)
    {
        List<int> listOfHourGlassSums = new List<int>();
        List<List<int>> subArr = new List<List<int>>();
        
        
        for(int i = 0; i < 4; ++i){
            for(int j = 0; j < 4; ++j){
                subArr = ExtractSubList(arr, i, j, 3, 3);
                int currentSum = giveSum(subArr);
                listOfHourGlassSums.Add(currentSum);
            }
        }
        
        
        int maxSum = listOfHourGlassSums.Max();
        //int indexOfMax = listOfHourGlassSums.IndexOf(maxSum);
        //subArr = listOf2DLists[indexOfMax];
        
         return maxSum;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
