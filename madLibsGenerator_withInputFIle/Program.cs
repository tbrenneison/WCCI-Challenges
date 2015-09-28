using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madLibsGenerator_withInputFIle
{
    class Program
    {
        static void Main(string[] args)
        {
            //write/record the first phrase and then pass off to recursive method "againAndAgain"
            string madLib = returnMadLib(); 
            Console.WriteLine(madLib);
            recordPhrase(madLib);
            againAndAgain();
        }//end of main method 


        static void recordPhrase(string madLib) //records every phrase in a text file (will overwrite the file each time the program runs, but saves each generated phrase)
        {
            StreamWriter writer = new StreamWriter("recordphrases.txt", true);
            using (writer)
            {
                writer.WriteLine(madLib);
            }
        }//end of recordPhrase method


        static void againAndAgain() //recursive method to generate phrases as long as the user wants to
        {
            Console.WriteLine("Would you like to generate another phrase? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
                 {
                string madLib = returnMadLib();
                Console.WriteLine(madLib);
                recordPhrase(madLib);
                againAndAgain();
                 }
            else
                 { return; }
        } //end of againAndAgain method


        static string returnMadLib() //heavy lifting 
        {
            string[] lines = File.ReadAllLines("inputfile.txt"); //reads all lines of a file and creates string[]

            //suppose this is kind of cheating because I formatted the text file to split nicely but it's my file and no one said I couldn't, so... 
            string[] nouns = lines[0].Split(',');
            string[] verbs = lines[1].Split(',');
            string[] prepPhrases = lines[2].Split(',');


            //new random instance and random numbers for each string[] 
            Random rnd = new Random();
            int n = rnd.Next(1, nouns.Length - 1);
            int v = rnd.Next(1, verbs.Length - 1);
            int pP = rnd.Next(1, prepPhrases.Length - 1);
            //words chosen at random index of respective string[] 
            string noun = nouns[n];
            string verb = verbs[v];
            string prepPhrase = prepPhrases[pP];
            //put them together with StringBuilder
            StringBuilder madLib = new StringBuilder();
            madLib.Append(noun + " " + verb + " " + prepPhrase + ".");
            return madLib.ToString();

        }//end of returnMadLib method

    }
}
