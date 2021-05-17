using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QU.Challenge.App.Presentation
{
    public class LayoutService : ILayoutService
    {
        string stopChar = "X";
        string enteredValue = "";

        /// <summary>
        /// Prompts the user to enter the size of the matrix to build
        /// </summary>
        /// <returns></returns>
        public int PrintFirstBlock()
        {
            int resp = 0;

            try
            {
                Console.Write("============================\nStep #1:\n");
                Console.Write("Please set the matrix width (a number greater than 0 and lower than 65) : ");

                Int32 wordSize = 0;
                string enteredSize;

                do
                {

                    enteredSize = Console.ReadLine();

                    if (Regex.IsMatch(enteredSize, @"^\d+$"))
                    {
                        wordSize = Convert.ToInt32(enteredSize);

                        if (wordSize > 0 && wordSize <= 64)
                        {
                            resp = wordSize;
                            break;
                        }
                        else
                        {
                            Console.Write("\nOops, that was not a valid value, please enter a number greater than 0 and lower than 65 (or X to exit): ");
                        }
                    }
                    else
                    {
                        if (enteredSize != "X")
                            Console.Write("\nOops, that was not a number, please enter a valid value (or X to exit): ");
                    }
                } while (enteredSize != stopChar);

            }
            catch(Exception err)
            {
                Console.Write("\n============================\nError!\n");
                Console.Write(err.Message);
                Console.Write("\n============================\n");
            }

            return resp;

        }

        /// <summary>
        /// Prompt user to enter the words to build the matrix
        /// </summary>
        /// <param name="sizewordLength"></param>
        /// <returns></returns>
        public List<string> PrintSecondBlock(int wordLength)
        {
            List<string> result = new List<string>();

            try
            {
                Console.Write("============================\nStep #2:\n");

                while (enteredValue != stopChar && result.Count < wordLength)
                {
                    Console.Write("Please type a new word for the new matrix instance (or enter " + stopChar + " to finish): ");
                    enteredValue = Console.ReadLine();

                    if (enteredValue != stopChar)
                    {
                        result.Add(enteredValue);
                        Console.Write("New word successfully added to matrix!\n\n");
                    }

                }
            }catch(Exception err)
            {
                Console.Write("\n============================\nError!\n");
                Console.Write(err.Message);
                Console.Write("\n============================\n");
            }

            return result;
        }

        /// <summary>
        /// Prompts the user to type the word(s) to search in the matrix
        /// </summary>
        /// <param name="sizewordLength"></param>
        /// <returns></returns>
        public List<string> PrintThirdBlock()
        {
            List<string> result = new List<string>();

            try
            {

                Console.Write("\n============================\nStep #3:\n");

                enteredValue = "";

                while (enteredValue != stopChar)
                {
                    Console.Write("Please type a new word for the search word stream (or enter " + stopChar + " to finish): ");
                    enteredValue = Console.ReadLine();

                    if (enteredValue != stopChar)
                    {
                        result.Add(enteredValue);
                        Console.Write("New word successfully added to stream!\n\n");
                    }
                }

            }
            catch (Exception err)
            {
                Console.Write("\n============================\nError!\n");
                Console.Write(err.Message);
                Console.Write("\n============================\n");
            }

            return result;
        }

        public void PrintMatrix(char[,] matrix)
        {
            var limit = Math.Sqrt(matrix.Length);

            Console.WriteLine("\n\n============================");

            Console.WriteLine("\nYour word matrix is:");

            for (int i = 0; i < limit; i++)
            {

                for (int q = 0; q < (limit * 5); q++)
                {
                    Console.Write("=");
                }

                Console.WriteLine("");

                Console.Write(" ");

                for (int j = 0; j < limit; j++)
                {
                    Console.Write(matrix[i, j] + " || ");
                }
                
                Console.WriteLine();

                for (int k = 0; k < (limit * 5); k++)
                {
                    Console.Write("=");
                }

                Console.WriteLine();

            }

        }

        public void PrintWordsForSearch(IEnumerable<string> words)
        {
            IList<string> list = (IList<string>)words;

            Console.WriteLine("\n============================");

            Console.WriteLine("\nThe words for search in the matrix are:\n");

            foreach(string word in list)
            {
                Console.WriteLine("=> \"" + word + "\"");
            }

        }

        public void PrintFindings(FindResult_Response result)
        {
            Console.WriteLine("\n============================");

            if (result.Words.Count > 0)
            {
                Console.WriteLine("\n...And the top findings are:\n");

                int i = 1;

                foreach (Word_Response word in result.Words)
                {
                    Console.WriteLine(i + ".- \"" + word.Value + "\" ==> " + word.Count + " time(s).");
                    i++;
                }
            }
            else
                Console.Write("None of the provided words where found in the matrix.");

            Console.WriteLine("\nThank you!");
            Console.WriteLine("\n============================\n\n");

        }

        public void PrintExceptionMsg(string msg)
        {
            Console.WriteLine("\n============================");

            Console.WriteLine("\nAn exception (error) was catched: "+ msg +"\nPlease try again...\n");
        }

    }
}
