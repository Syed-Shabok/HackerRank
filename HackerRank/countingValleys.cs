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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    public static int countingValleys(int steps, string path)
    {
        int seaLevel = 0;
        int pos = seaLevel;
        List<int> trackingList = new List<int>();
        
        for(int i = 0; i < steps; ++i){
            if((pos == 0 && path[i]== 'D') || (pos == -1 && path[i] == 'U')){
                trackingList.Add(1);
            }
            if(path[i] == 'D'){
                --pos;
            }
            else{
                ++pos;
            }
        }
        
        string s = "";
        foreach(int element in trackingList){
            s += $"{element}, ";
        }
        Console.WriteLine(s);
        
        int tracker = trackingList.Count(x => x == 1);
        int noOfValleys = tracker / 2;
        
        return noOfValleys;    
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
