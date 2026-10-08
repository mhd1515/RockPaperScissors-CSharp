using System;
using System.IO;

class Program
{
    static void Main()
    {
        string databaseFile = "database.txt";

        int playerScore = 0;
        int computerScore = 0;
        int drawScore = 0;

        Random random = new Random();

        Console.WriteLine("================================");
        Console.WriteLine("     bazi sang kaghaz gheychi");
        Console.WriteLine("================================");

        Console.Write("enter player name: ");
        string playerName = Console.ReadLine();

        if (!File.Exists(databaseFile))
        {
            File.WriteAllText(databaseFile,
                "===== Rock Paper Scissors Database =====\n");
        }

        bool playing = true;

        while (playing)
        {
            Console.WriteLine();
            Console.WriteLine("---------- game menu ----------");
            Console.WriteLine("1. sang");
            Console.WriteLine("2. kaghaz");
            Console.WriteLine("3. gheychi");
            Console.WriteLine("4. score screen");
            Console.WriteLine("5. history game");
            Console.WriteLine("0. exit");
            Console.Write("your choice: ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                playing = false;
                continue;
            }

            if (input == "4")
            {
                Console.WriteLine();
                Console.WriteLine("---------- score ----------");
                Console.WriteLine("player: " + playerScore);
                Console.WriteLine("mpc: " + computerScore);
                Console.WriteLine("draw: " + drawScore);
                continue;
            }

            if (input == "5")
            {
                Console.WriteLine();
                Console.WriteLine("---------- history game ----------");

                string history = File.ReadAllText(databaseFile);
                Console.WriteLine(history);

                continue;
            }

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("choice faile!");
                continue;
            }

            int computerChoice = random.Next(1, 4);

            string playerChoice = GetChoiceName(int.Parse(input));
            string computerChoiceName = GetChoiceName(computerChoice);

            Console.WriteLine();
            Console.WriteLine("your choice: " + playerChoice);
            Console.WriteLine("mpc choice: " + computerChoiceName);

            string result;

            if (int.Parse(input) == computerChoice)
            {
                result = "Draw";
                drawScore++;

                Console.WriteLine("result: draw!");
            }
            else if (
                (int.Parse(input) == 1 && computerChoice == 3) ||
                (int.Parse(input) == 2 && computerChoice == 1) ||
                (int.Parse(input) == 3 && computerChoice == 2)
            )
            {
                result = "Win";
                playerScore++;

                Console.WriteLine("result: you winner!");
            }
            else
            {
                result = "Lose";
                computerScore++;

                Console.WriteLine("result: mpc winner!");
            }

            string record =
                "Player: " + playerName +
                " | PlayerChoice: " + playerChoice +
                " | ComputerChoice: " + computerChoiceName +
                " | Result: " + result +
                Environment.NewLine;

            File.AppendAllText(databaseFile, record);
        }

        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine("game over.");
        Console.WriteLine("your final score : " + playerScore);
        Console.WriteLine("mpc final score: " + computerScore);
        Console.WriteLine("draw score: " + drawScore);
        Console.WriteLine("================================");

        Console.WriteLine("baray khoroj exit bezanid...");
        Console.ReadLine();
    }

    static string GetChoiceName(int choice)
    {
        if (choice == 1)
            return "Rock";

        if (choice == 2)
            return "Paper";

        return "Scissors";
    }
}
