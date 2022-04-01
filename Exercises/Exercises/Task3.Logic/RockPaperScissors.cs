using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task3.Logic
{
    public class RockPaperScissors : Game
    {
        private Random _rand = new Random();

        public Player Player { get; set; }
        public Player Cpu { get; set; }

        public RockPaperScissors()
        {
            Player = new Player() { Name = "Player One" };
            Cpu = new Player() { Name = "Cpu" };
        }

        public void InGame()
        {
            Console.WriteLine("ROCK PAPER SCISSORS");
            Console.WriteLine("Let`s play...." );

            while (true)
            {
                Console.WriteLine("1) Start Round 2) View Stats 3) Quit");

                bool IsValid = int.TryParse(Console.ReadLine(), out int selection);
                if (!IsValid)
                {
                    Console.WriteLine("No valid input.Please select one of given menu options.");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        PlayerStats();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for playing Rock Paper Scissors. Have a nice day!!! ");
                        Thread.Sleep(3000);
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Invalid menu selection");
                        break;
                }
            }
        }
        private void StartGame()
        {
            IsActiv = true;

            while (IsActiv)
            {
                Console.WriteLine("1) Start Round \n 2) End Round");
                bool isValid = int.TryParse(Console.ReadLine(), out int selection);

                if (!isValid)
                {
                    Console.WriteLine("Not valid input. Please select one of the given menu options.");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        PlayRound();
                        break;
                    case 2:
                        IsActiv = !IsActiv;
                        break;
                    default:
                        Console.WriteLine("Invalid menu selection!!!");
                        break;
                }
            }
        }


        public void PlayRound()
        {
            Console.WriteLine("1) Rock \n 2) Paper \n 3) Scissors");
            bool isValid = int.TryParse(Console.ReadLine(), out int selection);

            if (!isValid)
            {
                Console.WriteLine("Not valid input. Please select one of the given menu options.");
                return;
            }

            RoundResult result = RoundResult(selection);
            string winnerName = string.Empty;

            if(result.Winner == 1)
            {
                winnerName = Player.Name;
                Player.Won += 1;
                Cpu.Lost += 1;
            }
            else if (result.Winner == 2)
            {
                winnerName = Cpu.Name;
                Player.Lost += 1;
                Cpu.Won += 1;
            }
            else
            {
                Player.Draw += 1;
                Cpu.Draw += 1;
                Console.WriteLine(result.Message);
            }

            IncreaseGamePlayed();
            if (!string.IsNullOrWhiteSpace(winnerName))
            {
                Console.WriteLine($"{result.Message} \n Winner  {winnerName} in round {GetGamesPlayed()} ");
            }

        }

        private RoundResult RoundResult(int playerSelection)
        {
            RoundResult result = new RoundResult();
            int cpuSelection = _rand.Next(1, 4);

            //rulles of winning the game
            if(playerSelection == cpuSelection)
            {
                result.Winner = 0;
                result.Message = "It`s a darw";
                return result;
            }

            switch (cpuSelection)
            {
                case 1:
                    if(playerSelection == 2)
                    {
                        result.Winner = 2;
                        result.Message = "Rock crushes scissors or somethimes blunts them.";
                    } else if (playerSelection == 3)
                    {
                        result.Winner = 1;
                        result.Message = "Paper cover rock.";
                    }
                    break;
                case 2:
                    if(playerSelection == 1)
                    {
                        result.Winner = 1;
                        result.Message = "Paper cover rock.";
                    }
                    else if(playerSelection == 3)
                    {
                        result.Winner = 1;
                        result.Message = "Sicssors cut paper.";
                    }
                    break;
                case 3:
                    if(playerSelection == 1)
                    {
                        result.Winner = 1;
                        result.Message = "Rock crushes scissors or somethimes blunts them.";
                    }
                    else if(playerSelection == 2)
                    {
                        result.Winner = 2;
                        result.Message = "Sicssors cut paper";
                    }
                    break;
            }
            return result;
        }

        private void PlayerStats()
        {
            Console.WriteLine($"{Player.Name} stats");
            Console.WriteLine($"Won: {Player.Won} Lost: {Player.Lost} Draw: {Player.Draw} Win%: {CalculateWinPercent(GetGamesPlayed(), Player.Won)}");

            Console.WriteLine($"{Cpu.Name} stats");
            Console.WriteLine($"Won: {Cpu.Won} Lost: {Cpu.Lost} Draw: {Cpu.Draw} Win%: {CalculateWinPercent(GetGamesPlayed(), Cpu.Won)}");

        }

        private double CalculateWinPercent(int played, int won)
        {
            try
            {
                return (played / won) * 100;
            }
            catch (DivideByZeroException)
            {

                return 0; ;
            }
        }
    }
}
