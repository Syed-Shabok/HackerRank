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
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */

    public static bool isEven(int num){
        if(num % 2 ==0){
            return true;
        }
        else{
            return false;
        }
    }
    

    public static int pageCount(int n, int p)
    {
        List<int> bookPages = new List<int>();
        int frontFlips = 0;
        int backFlips = 0;
        
    
        if(isEven(n)){
     
            for(int i = 0; i < n + 2; ++i){
                bookPages.Add(i); 
            }
            
            //
            if(isEven(p)){
                 
                for(int i = 0; i < n + 1; i = i + 2){
                    if(bookPages[i] == p){
                        break;
                    }
                    ++frontFlips;
                }
                
    
                for(int i = n + 1; i >= 1; i = i - 2){
                    if(bookPages[i - 1] == p){
                        break;
                    }
                    ++backFlips;
                }
            }
            
            else{
            
                for(int i = 0; i < n + 1; i = i + 2){
                    if(bookPages[i + 1] == p){
                        break;
                    }
                    ++frontFlips;
                }
                
                for(int i = n + 1; i >= 1; i = i - 2){
                    if(bookPages[i] == p){
                        break;
                    }
                    ++backFlips;
                }
            }
        }
        
        else{
            
            for(int i = 0; i < n + 1; ++i){
                bookPages.Add(i); 
            }
            
            if(isEven(p)){
            
                for(int i = 0; i < n; i = i + 2){
                    if(bookPages[i] == p){
                        break;
                    }
                    ++frontFlips;
                }
                
                for(int i = n; i >= 0; i = i - 2){
                    if(bookPages[i - 1] == p){
                        break;
                    }
                    ++backFlips;
                }
            }
            
            else{
            
                for(int i = 0; i < n; i = i + 2){
                    if(bookPages[i + 1] == p){
                        break;
                    }
                    ++frontFlips;
                }
                
                for(int i = n; i >= 0; i = i - 2){
                    if(bookPages[i] == p){
                        break;
                    }
                    ++backFlips;
                }
            }
        }
        
        int minFlips = (frontFlips < backFlips ? frontFlips: backFlips);
            
        Console.WriteLine($"Font Flips: {frontFlips}");
        Console.WriteLine($"Back Flips: {backFlips}");
        Console.WriteLine($"Min Flips: {minFlips}");
                
        
        
        return (minFlips);
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.pageCount(n, p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
