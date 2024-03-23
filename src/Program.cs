using System;

namespace FunctionChallenges
{
    class Program
    {
        // Challenge 1
        static void StringNumberProcessor(params object[] inputs){
            string totalString = "";
            int totalNum = 0;

            foreach (var input in inputs){
            try
            {
                if (input is string){
                    totalString += input + " ";
                }
                else if (input is int || input is double || input is float){
                    totalNum += Convert.ToInt32(input);
                }
            }
            catch (Exception ex)
            {
            Console.WriteLine("Error: " + ex.Message);
            }
            }

        Console.WriteLine($"{totalString.TrimEnd()}; {totalNum}");
        }

        // Challenge 2
        static void SwapObjects(ref int num1, ref int num2)
        {
            if (num1 > 18 && num2 > 18)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
                Console.WriteLine($"num1 = {num1}, num2 = {num2}");       
            }
            else
            {
                Console.WriteLine("Error: Value must be more than 18");
            }

        }
        static void SwapObjects(string str1, string str2)
        {
             // Check if the lengths of strings are more than 5
            if (str1.Length > 5 && str2.Length > 5)
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
                Console.WriteLine($"str1 = {str1}, str2 = {str2}");
            }
            else
            {
                Console.WriteLine("Error:Length must be more than 5");
            }

        }
        static void SwapObjects( object obj1, object obj2)
        {
            if (obj1.GetType() != obj2.GetType()){
                Console.WriteLine("Error: Objects must be of the same types");
            }
            else
            {
                Console.WriteLine("Error: Unsupported data type");
            }
        
        }
        // Challenge 3
        static void GuessingGame()
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 101);

            Console.WriteLine("Try to guess the number between 1 and 100. Enter 'Quit' to exit.");
            while (true)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                try
                {
                    if (input.ToLower() == "quit")
                    {
                        Console.WriteLine("Game over. The correct number was: " + targetNumber);
                        break;
                    }

                    int guess = Convert.ToInt32(input);

                    if (guess < 1 || guess > 100)
                    {
                        Console.WriteLine("Invalid guess. Please enter a number between 1 and 100.");
                        continue;
                    }

                    if (guess < targetNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (guess > targetNumber)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You guessed the correct number: {targetNumber}");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Challenge 4
        static string ReverseWords(string sentence)
        {
            try
            {
                string[] words = sentence.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    char[] charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    words[i] = new string(charArray);
                }

                string reversedSentence = string.Join(" ", words);
                return reversedSentence;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return string.Empty;
            }
        }

        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"
            StringNumberProcessor("Welcome", 80.5, "to",375.56, "SDA",500);

             // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";
                          
            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(str1, str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(str3, str4); // Error: Length must be more than 5

            SwapObjects(true, false); // Error: Upsupported data type
            SwapObjects(num1, str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`
            
            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            //string sentence = "Welcome to SDA";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
    }
}
