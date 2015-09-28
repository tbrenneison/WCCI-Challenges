using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madLibsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //write the first generated phrase ("returnMadLib") and then call the recursive method "againAndAgain"
            Console.WriteLine(returnMadLib());
            againAndAgain();
       
        } //end of main method, do not lose this jerkface bracket 


        static void againAndAgain() //recursive method to generate phrases as long as the user wants to
        {
            Console.WriteLine("Would you like to generate another phrase? Y/N");
            if (Console.ReadLine() == "Y")
            {
                Console.WriteLine(returnMadLib());
                againAndAgain();
            }
            else
            { return; }
        } //end of againAndAgain method, do not lose this jerkface bracket either

 
        static string returnMadLib() //heavy lifting 
        {
            //word/phrase data 
            string[] nouns = { "She", "He", "It", "The cat", "The mongoose", "The orange", "The trampoline", "Musicians", "Programmers", "The shake" };
            string[] verbs = { "ate", "barbequed", "chirped", "collided", "sang", "spoke", "cartwheeled", "dined", "watched", "directed" };
            string[] prepPhrases = { "with the monkeys", "on the porch", "under the moon", "after the storm", "before the prince", "over the lake", "in the gazebo", "between the lines", "during the festival", "with them all" };
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

        }//again with the losing of jerkface brackets, don't do it


    }
}
