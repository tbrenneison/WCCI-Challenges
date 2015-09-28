using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removeHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //if the file doesn't exist... 
            if (!File.Exists("problem1.html"))
                {
                Console.WriteLine("File not found.");
                return;
                 }
           
            //if the file DOES exist... 
            string line; 
            StreamReader reader = new StreamReader("problem1.html");
            StreamWriter writer = new StreamWriter("problemone.txt");
            using (reader)
            {
                while ((line = reader.ReadLine()) != null) //reads input file one line at a time
                {
                    if(!string.IsNullOrEmpty(line)) //if string is not null or empty
                        {
                        line = MakeTagless(line);
                        line = RemoveDblLines(line);
                        line = TrimNewLines(line);
                        Console.WriteLine(line);
                        writer.WriteLine(line);
                        }
                }
                writer.Close(); //BUT I STILL FEEL LIKE THERE ARE A LOT OF NEW LINES IN THE OUTPUT DOCUMENT.  I DO NOT APPROVE.
            }

        }//end of main method 

        static string MakeTagless(string str)
        {
            string sansTags = Regex.Replace(str, "<[^>]*>", "\n");
            return sansTags;
        }//end of MakeTagless method

        static string RemoveDblLines(string str)
        {
            string removedLines = Regex.Replace(str, "[\n]+", "\n");
            return removedLines;
        }//end of RemoveDblLines method

        static string TrimNewLines(string str)
        {
            //goes left-right looking for line breaks
            int start = 0;
            while (start < str.Length && str[start] == '\n') 
                {
                start++;
                }

            //goes right-left looking for line breaks
            int end = str.Length - 1;
            while (end >= 0 && str[end] == '\n')
             {
                end--;
             }

            //determines if string is empty
            if (start > end)
                {
                return string.Empty;
                }

            string trimmed = str.Substring(start, end - start + 1); //removes line breaks from start and end of lines
            return trimmed;
        }//end of TrimNewLines

    }
}
