using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a string comprising just of the characters (,),{,},[,] determine if it is well-formed or not.
            //Each line in this file contains a string comprising of the characters mentioned above.
            //Print out True or False if the string is well-formed.

            //if opening bracket, push to stack
            //if closing bracket, peek stack and see if top char is matching opening bracket 
            //if yes, pop stack 
            //if stack count = 0, brackets are well-formed 

            string line = "([)]";//test input (false)

            char[] chars = line.ToCharArray();
            Stack<char> charStack = new Stack<char>();

            foreach(char c in chars) //consider each character left-right 
            {
                if (c == '(' || c == '[' || c == '{') //push opening brackets to stack
                {
                    charStack.Push(c);
                }
                else if (charStack.Count() > 0) //compare closing brackets to top of stack to see if they match opening bracket
                {
                    char x = c;
                    char y = charStack.Peek();
                    switch (x) //pop the stack if the brackets close up
                    {
                        case ')':
                            if (y == '(')
                            { charStack.Pop(); }
                            break;
                        case ']':
                            if (y == '[')
                            { charStack.Pop(); }
                            break;
                        case '}':
                            if (y == '{')
                            { charStack.Pop(); }
                            break;
                        default:
                            break;
                    }
                }
                else//if first bracket is a closing bracket 
                {
                    continue;
                }
            }

            //if the stack is empty, return true 
            if(charStack.Count > 0) 
            { Console.WriteLine("False"); }
            else
            { Console.WriteLine("True"); }

            

        }
    }
}
