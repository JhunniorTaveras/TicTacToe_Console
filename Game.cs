using System;

namespace TicTacToe
{
    class Game
    {
        readonly string[] plays = { "1 1", "1 2", "1 3", "2 1", "2 2", "2 3", "3 1", "3 2", "3 3" };
        readonly char[] moves = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        string coordinate;
        int counterXO = 0;
        private readonly Random random = new Random();
        bool endGame = true;

        private void OneVsOne()
        {
            Console.WriteLine("Enter the coordinates: (x,y)");
            ShowBoard();
            
            do
            {
                Console.Write("Enter the coordinates: ");
                coordinate = Console.ReadLine();
                CheckMove(coordinate);

            } while (endGame);

            NewGame();
        }

        private void ShowBoard()
        {
            Console.WriteLine("---------");
            Console.WriteLine($"| {moves[0]} {moves[1]} {moves[2]} |");
            Console.WriteLine($"| {moves[3]} {moves[4]} {moves[5]} |");
            Console.WriteLine($"| {moves[6]} {moves[7]} {moves[8]} |");
            Console.WriteLine("---------");
        }
    
        private bool ValidMove()
        {
            for (int i = 0; i < plays.GetLength(0); i++)
            {
                if (plays[i].Equals(coordinate))
                {
                    if (moves[i].Equals('-'))
                    {
                        if (counterXO % 2 == 0)
                        {
                            moves[i] = 'X';
                        }
                        else
                        {
                            moves[i] = 'O';
                        }
                        counterXO++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private bool EndGame()
        {
            if (moves[0].Equals(moves[1]) && moves[1].Equals(moves[2]) && !(moves[1].Equals('-')))
            {
                return true;
            }
            else if (moves[3].Equals(moves[4]) && moves[4].Equals(moves[5]) && !(moves[4].Equals('-')))
            {
                return true;
            }
            else if (moves[6].Equals(moves[7]) && moves[7].Equals(moves[8]) && !(moves[7].Equals('-')))
            {
                return true;
            }
            else if (moves[0].Equals(moves[3]) && moves[3].Equals(moves[6]) && !(moves[3].Equals('-')))
            {
                return true;
            }
            else if (moves[1].Equals(moves[4]) && moves[4].Equals(moves[7]) && !(moves[4].Equals('-')))
            {
                return true;
            }
            else if (moves[2].Equals(moves[5]) && moves[5].Equals(moves[8]) && !(moves[5].Equals('-')))
            {
                return true;
            }
            else if (moves[0].Equals(moves[4]) && moves[4].Equals(moves[8]) && !(moves[4].Equals('-')))
            {
                return true;
            }
            else if (moves[6].Equals(moves[4]) && moves[4].Equals(moves[2]) && !(moves[4].Equals('-')))
            {
                return true;
            }
            return false;
        }

        private void NewGame()
        {
            Console.WriteLine("Play again? si/no");
            string juego = Console.ReadLine();

            coordinate = null;
            counterXO = 0;
            endGame = true;

            for (int i = 0; i < moves.Length; i++)
            {
                moves[i] = '-';
            }

            if (juego.ToLower() == "si")
            {
				Console.Clear();
                Menu();
            }
        }

        public void Menu()
        {
            Console.Title = "Tic Tac Toe";

            Console.WriteLine("Please select a number: ");
            Console.WriteLine("1. 1 vs 1");
            Console.WriteLine("2. 1 vs Computer");

            string option = Console.ReadLine();

            Console.Clear();

            if (option == "1")
            {
                OneVsOne();
            }
            else if(option == "2")
            {
                OneVsComputer();   
            }
        }

        private void OneVsComputer()
        {
            Console.WriteLine("Enter the coordinates: (x,y)");
            ShowBoard();
            
            do
            {

                if (counterXO % 2 == 0)
                {
                    Console.Write("Enter the coordinates: ");
                    coordinate = Console.ReadLine();
                    CheckMove(coordinate);
                }
                else
                {
                    Console.ReadKey();
                    for (int i = 0; i < plays.Length; i++)
                    {
                        coordinate = plays[random.Next(9)];
                        if (CheckMove(coordinate))
                        {
                            break;
                        }
                    }
                }

            } while (endGame);

            NewGame();
        }

        private bool CheckMove(string coordinate)
        {
            if (ValidMove())
            {
                Console.Clear();
                ShowBoard();

                if (EndGame())
                {
                    if (counterXO % 2 == 0)
                    {
                        Console.WriteLine("O Won!");
                    }
                    else
                    {
                        Console.WriteLine("X Won!");
                    }
                    endGame = false;    
                }
                else if (counterXO > 8)
                {
                    Console.WriteLine("Tie!");
                    endGame = false;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Move. Please try again.");
                return false;
            }
        }
    }
}
