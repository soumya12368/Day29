using System;


namespace Assignment_23
{
    public delegate void SpinDelegate(ref int energyLevel, ref int winningProbability);

    class LuckySpinGame
    {
        static void Main()
        {
            Console.WriteLine("Enter Your Name:");
            string playerName = Console.ReadLine();

            Console.WriteLine("Enter Your Lucky Number from 1 to 10:");
            int luckyNumber;
            while (!int.TryParse(Console.ReadLine(), out luckyNumber) || luckyNumber < 1 || luckyNumber > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
            }

            int energyLevel = 1;
            int winningProbability = 100;
            int numberOfSpins = 5;

            SpinDelegate spinDelegate = Spin;

            for (int spinNumber = 1; spinNumber <= numberOfSpins; spinNumber++)
            {
                Console.WriteLine($"Spin {spinNumber}:");
                spinDelegate(ref energyLevel, ref winningProbability);
                Console.WriteLine($"Energy Level: {energyLevel}, Winning Probability: {winningProbability}%");
            }

            Console.WriteLine("\nGame Over!");

            // Determine the game result
            if (energyLevel >= 4 && winningProbability > 60)
            {
                Console.WriteLine($"Winner: {playerName}");
            }
            else if (energyLevel >= 1 && winningProbability > 50)
            {
                Console.WriteLine($"Runner Up: {playerName}");
            }
            else
            {
                Console.WriteLine($"Looser: {playerName}");
            }
        }

        static void Spin(ref int energyLevel, ref int winningProbability)
        {
            // Adjust energy level and winning probability based on spin rules
            if (energyLevel < 0)
            {
                // Ensure energy level does not go below 0
                energyLevel = 0;
            }

            if (winningProbability < 0)
            {
                // Ensure winning probability does not go below 0
                winningProbability = 0;
            }

            // Define spin rules
            switch (energyLevel)
            {
                case 1:
                    energyLevel += 1;
                    winningProbability += 10;
                    break;

                case 2:
                    energyLevel += 2;
                    winningProbability += 20;
                    break;

                case 3:
                    energyLevel -= 3;
                    winningProbability -= 30;
                    break;

                case 4:
                    energyLevel += 4;
                    winningProbability += 40;
                    break;

                case 5:
                    energyLevel += 5;
                    winningProbability += 50;
                    break;

                case 6:
                    energyLevel -= 1;
                    winningProbability -= 60;
                    break;

                case 7:
                    energyLevel += 1;
                    winningProbability += 70;
                    break;

                case 8:
                    energyLevel -= 2;
                    winningProbability -= 20;
                    break;

                case 9:
                    energyLevel -= 3;
                    winningProbability -= 30;
                    break;

                case 10:
                    energyLevel += 10;
                    winningProbability += 100;
                    break;

                    // Add more cases for different energy levels if needed
            }
        }
    }
}
