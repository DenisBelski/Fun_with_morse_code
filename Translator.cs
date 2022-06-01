using System;
using System.Globalization;
using System.Text;

namespace FunWithMorseCode
{
    public static class Translator
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console App 'Fun with morse code'");
            Console.WriteLine("---------------------------------");

            while (!endApp)
            {
                string result = string.Empty;
                string inputString = string.Empty;

                Console.WriteLine("\nEnter the word, phrase or sentence you want to convert to morse code:");
                inputString = Console.ReadLine();

                bool correctInput = false;

                while (!correctInput)
                {
                    if (string.IsNullOrWhiteSpace(inputString))
                    {
                        correctInput = false;
                        Console.Write("String cannot be empty or contain only spaces. Try again to enter the string:\n");
                        inputString = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < inputString.Length; i++)
                    {
                        if (char.IsLetter(inputString[i])
                            || inputString[i] == ' '
                            || inputString[i] == '.'
                            || inputString[i] == ','
                            || inputString[i] == '!'
                            || inputString[i] == '?'
                            )
                        {
                            correctInput = true;
                        }
                        else
                        {
                            correctInput = false;
                            Console.Write("This is not valid input. Please enter only letters of the English alphabet:\n");
                            inputString = Console.ReadLine();
                            break;
                        }
                    }
                }

                result = TranslateToMorse(inputString);

                Console.WriteLine($"Your result in Morse code:\n {result}\n");
                Console.WriteLine("---------------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue:");
                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }
            }
        }

        public static string TranslateToMorse(string message)
        {
            var codeTable = MorseCodes.CodeTable;
            StringBuilder result = new StringBuilder();
            char[] separator = new char[] { ' ', '.', ',', '!', '?' };

            message = message.Trim(separator);

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < codeTable.Length; j++)
                {
                    if (message.ToUpper(CultureInfo.CurrentCulture)[i] == codeTable[j][0])
                    {
                        for (int k = 1; k < codeTable[j].Length; k++)
                        {
                            result.Append(codeTable[j][k]);
                        }

                        if (i < message.Length - 1)
                        {
                            result.Append(' ');
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}