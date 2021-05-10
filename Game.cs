using System;

namespace TicTacToe
{
    class Game
    {
        readonly string[] plays = { "1 1", "1 2", "1 3", "2 1", "2 2", "2 3", "3 1", "3 2", "3 3" };
        readonly char[] moves = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        string coordinate;
        int counterXO = 0;

        public void StartGame()
        {
            Console.Title = "Tic Tac Toe";

            Console.WriteLine("Inserte las coordenadas: (x,y)");
            ShowBoard();
            
            do
            {
                Console.Write("Inserte las coordenadas: ");
                coordinate = Console.ReadLine();

                if (ValidMove())
                {
                    ShowBoard();

                    if (EndGame())
                    {
                        if (counterXO % 2 == 0)
                        {
                            Console.WriteLine("O Gano!");
                        }
                        else
                        {
                            Console.WriteLine("X Gano!");
                        }
                        break;
                    }
                    else if (counterXO > 8)
                    {
                        Console.WriteLine("Empate!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento Invalido. Intentelo de nuevo.");
                }

            } while (true);

            Console.WriteLine("Desea jugar de nuevo? si/no");
            string juego = Console.ReadLine();

            if (juego.ToLower() == "si")
            {
				Console.Clear();
                NewGame();
            }
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
            for (int x = 0; x < plays.Length; x++)
            {
                if (plays[x].Equals(coordinate))
                {
                    if (moves[x].Equals('-'))
                    {
                        if (counterXO % 2 == 0)
                        {
                            moves[x] = 'X';
                        }
                        else
                        {
                            moves[x] = 'O';
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
            if ((moves[0].Equals(moves[1]) && moves[1].Equals(moves[2])) && (!moves[1].Equals('-')))
            {
                return true;
            }
            else if ((moves[3].Equals(moves[4]) && moves[4].Equals(moves[5])) && (!moves[4].Equals('-')))
            {
                return true;
            }
            else if ((moves[6].Equals(moves[7]) && moves[7].Equals(moves[8])) && (!moves[7].Equals('-')))
            {
                return true;
            }
            else if ((moves[0].Equals(moves[3]) && moves[3].Equals(moves[6])) && (!moves[3].Equals('-')))
            {
                return true;
            }
            else if ((moves[1].Equals(moves[4]) && moves[4].Equals(moves[7])) && (!moves[4].Equals('-')))
            {
                return true;
            }
            else if ((moves[2].Equals(moves[5]) && moves[5].Equals(moves[8])) && (!moves[5].Equals('-')))
            {
                return true;
            }
            else if ((moves[0].Equals(moves[4]) && moves[4].Equals(moves[8])) && (!moves[4].Equals('-')))
            {
                return true;
            }
            else if ((moves[6].Equals(moves[4]) && moves[4].Equals(moves[2])) && (!moves[4].Equals('-')))
            {
                return true;
            }
            return false;
        }
    
        private void NewGame()
        {
            coordinate = null;
            counterXO = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                moves[i] = '-';
            }

            StartGame();
        }
    }
}
