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
                            || char.IsDigit(inputString[i])
                            )
                        {
                            correctInput = true;
                        }
                        else
                        {
                            correctInput = false;
                            Console.Write("This is not valid input. Please enter numbers or letters of the English alphabet:\n");
                            inputString = Console.ReadLine();
                            break;
                        }
                    }
                }

                result = TranslateToMorse(inputString);

                Console.WriteLine($"Your result in Morse code:\n {result}\n");
                Console.WriteLine("---------------------------------\n");

                Console.Write("Do you want to translate text into Morse code?\nPress 'n' and Enter to close the app, or press any other key and Enter to continue:");
                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }

                Console.WriteLine("\nEnter the Morse code you want to convert to text: ");
                inputString = Console.ReadLine();
                correctInput = false;

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
                        if (inputString[i] == ' ' || inputString[i] == '.' || inputString[i] == '-')
                        {
                            correctInput = true;
                        }
                        else
                        {
                            correctInput = false;
                            Console.Write("This is not valid input. Please enter only '-', '.' or 'space':\n");
                            inputString = Console.ReadLine();
                            break;
                        }
                    }
                }

                result = TranslateToText(inputString);

                Console.WriteLine($"Your result in text form:\n {result}\n");
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

        public static string TranslateToText(string morseMessage)
        {
            var codeTable = MorseCodes.CodeTable;
            StringBuilder result = new StringBuilder();
            string[] arrayStrings = morseMessage.Split(' ');
            int count = 0;

            for (int i = 0; i < arrayStrings.Length; i++)
            {
                for (int j = 0; j < codeTable.Length; j++)
                {
                    StringBuilder temp = new StringBuilder();
                    count = 0;

                    for (int k = 1; k < codeTable[j].Length; k++)
                    {
                        temp.Append(codeTable[j][k]);
                    }

                    if (arrayStrings[i] == temp.ToString())
                    {
                        result.Append(codeTable[j][0]);
                        count++;
                    }
                }

                if (count == 0)
                {
                    result.Append("_");
                }
            }

            return result.ToString();
        }
    }
}