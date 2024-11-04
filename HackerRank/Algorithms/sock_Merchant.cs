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
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */

   public static int sockMerchant(int n, List<int> ar)
    {   
        List<int> quantityOfEachColor = new List<int>();
        int pairCounter = 0;
        
        //creating a list, each index of the list represents all possible colors.
        //Element at each index represents number of occurances of that color. 
        for(int i = 0; i < 101; ++i){
            quantityOfEachColor.Add((ar.Count(x => x == i)));
        }
        
        // string str1 = "";
        // for(int i = 0; i < 101; ++i){
        //     str1 += $"Color {i+1}: {quantityOfEachColor[i]} ";
        // }
        
        // Console.WriteLine(str1);
        
        
        //Checking to see how many pairs of each color are there.
        //the "/" operator returns the integer Quotient of the division. 
        for(int i = 0; i < 101; ++i){
            pairCounter += quantityOfEachColor[i] / 2;
        }
        
        return pairCounter;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
