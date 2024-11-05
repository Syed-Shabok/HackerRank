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
     * Complete the 'getMax' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY operations as parameter.
     */

    public static List<int> getMax(List<string> operations)
    {
        List<int> stack = new List<int>();
        List<int> results = new List<int>();
        
        for(int i = 0; i < operations.Count; ++i){
            //Splits the string by space chatecters ' ' and then converts to the 
            //seprated integer strings to integer types variables.
            //.ToList() is required cause .Select(int.Parse) returns an IEnumerable.
            List<int> intList = operations[i].Split(' ').Select(int.Parse).ToList();
            if(intList[0] == 1){
                stack.Add(intList[1]);
            }
            else if(intList[0] == 2){
                stack.RemoveAt(stack.Count -1);   
            }
            else{
                results.Add(stack.Max());
            }
        }
        
        return results;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> ops = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string opsItem = Console.ReadLine();
            ops.Add(opsItem);
        }

        List<int> res = Result.getMax(ops);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
