using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true) { 
            Console.WriteLine("### Hangman ###");
            Console.WriteLine("###############");
            Console.WriteLine();

            Console.WriteLine("Wähle eine Aktion aus:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1]Start [2]Beenden");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Aktion: ");
            int action = Convert.ToInt32(Console.ReadLine());
            bool end = false;

            switch (action)
            {
                case 1:
                        StartGame();
                    break;

                case 2:
                    end = true;
                        break;
            }

            if (end)
            {
                break;
            }

            Console.Clear();
        }
        }

        static void StartGame()
        {
            string[] words = new string[]
            {
                "Apfelkuchen",
                "Tetris",
                "Kraftknotensystem",
                "Kuschelbär",
                "Deutschland",
                "Kollege",
                "Regallager",
                "Vollkornbrot"
            };

            Random rnd = new Random();
            int index = rnd.Next(0, words.Length);
            string word = words[index].ToLower();

            GameLoop(word);

        }

        static void GameLoop(string word)
        {
            int lives = 10;
            string hiddenword = "";

            for (int i = 0; i < word.Length; i++)
            {
                hiddenword += "_";
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gesuchtes Wort: " + hiddenword);
                Console.Write("Noch übrige Versuche: ");

                for (int i = 0;i < lives ;i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }

                Console.WriteLine("");
                Console.Write("Buchstabe: ");
                char character = Convert.ToChar(Console.ReadLine().ToLower());

                bool foundCharacterInWord = false;

                for (int i = 0; i< word.Length; i++)
                {
                    if (word[i] == character)
                    {
                        foundCharacterInWord = true;
                        break;
                    }
                }

                string tempHiddenWord = hiddenword;
                hiddenword = "";

                if (foundCharacterInWord)
                {
                    for (int i = 0; i< word.Length ; i++)
                    {
                        if (word[i] == character)
                        {
                            hiddenword += character;
                        }

                        else if (tempHiddenWord[i] != '_')
                        {
                            hiddenword += tempHiddenWord[i];
                        }

                        else
                        {
                            hiddenword += '_';
                        }
                    }

                    if (hiddenword == word)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Gewonnen!");
                        Console.WriteLine("Das Wort war: " + word);
                        Console.ReadKey();
                        Console.ResetColor ();
                        break;
                    }
                }

                else
                {
                    hiddenword = tempHiddenWord;

                    if (lives >0 )
                    {
                        lives -= 1;

                    }

                    else
                    {
                        Console.Clear ();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game Over");
                        Console.ReadKey ();
                        Console.ResetColor ();

                        break;
                    }
                }
            }
        }
    }
}
