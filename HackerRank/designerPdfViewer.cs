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
     * Complete the 'designerPdfViewer' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY h
     *  2. STRING word
     */

    public static int designerPdfViewer(List<int> h, string word)
    {
        List<int> indices = new List<int>(); 
        
        foreach(char character in word){
            int asciiValue = character;
            // 97 is the ASCII value of the first lowercase alphabet 'a'. 
            int index = asciiValue - 97;
            indices.Add(index); 
        }
        
        List<int> charHeights = new List<int>();
        
        for(int i = 0; i < indices.Count; ++i){
            // Getting heights of each alphabet based on thier index.
            charHeights.Add(h[indices[i]]);
        }
        
        int maxHeight = charHeights.Max();
        
        return maxHeight * word.Length;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp)).ToList();

        string word = Console.ReadLine();

        int result = Result.designerPdfViewer(h, word);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
