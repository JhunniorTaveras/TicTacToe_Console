using System;
using System.Threading;

namespace TicTacToe
{
    class Game
    {
        // Definicion de las jugadas que el usuario puede hacer
        readonly string[] plays = { "1 1", "1 2", "1 3", "2 1", "2 2", "2 3", "3 1", "3 2", "3 3" };
        // Movimientos en el tablero
        readonly char[] moves = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        // String para capturar la jugada del usuario
        string coordinate;
        // int para definir si es X u O
        int counterXO = 0;
        private readonly Random random = new Random();
        bool endGame = true;

        private void OneVsOne()
        {
            Console.WriteLine("Enter the coordinates: (x,y)");
            ShowBoard();
            
            do
            {
                //Se captura la jugada del usuario
                Console.Write("Enter the coordinates: ");
                coordinate = Console.ReadLine();
                //Se verifica si la jugada es valida
                if (!CheckMove(coordinate))
                {
                    Console.WriteLine("Invalid Move. Please try again.");
                }

            } while (endGame);

            NewGame();
        }

        private void ShowBoard()
        {
            // Aqui se muestra el tablero
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
                //Se verifica si la jugada es valida
                if (plays[i].Equals(coordinate))
                {
                    //Se verifica que no hayan una pieza en la posicion
                    if (moves[i].Equals('-'))
                    {
                        // Se determina si es X u O
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
            Console.WriteLine("3. Computer vs Computer");

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
            else if (option == "3")
            {
                ComputerVsComputer();
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
                    // Se captura la jugada del usuario
                    Console.Write("Enter the coordinates: ");
                    coordinate = Console.ReadLine();
                    // Se verifica si el movimiento es valido
                    if (!CheckMove(coordinate))
                    {
                        Console.WriteLine("Invalid Move. Please try again.");
                    }
                }
                else
                {
                    Thread.Sleep(800);
                    // Se busca un movimiento valido dentro del array
                    for (int i = 0; i < plays.Length; i++)
                    {
                        coordinate = plays[random.Next(9)];
                        // Si el movimiento es valido sale del array
                        if (CheckMove(coordinate))
                        {
                            break;
                        }
                    }
                }

            } while (endGame);
            // Jugar de nuevo
            NewGame();
        }

        private bool CheckMove(string coordinate)
        {   
            // Se verifica si el movimiento es valido
            if (ValidMove())
            {
                Console.Clear();
                ShowBoard();
                // Se comprueba si el juego termino
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
                // Se comprueba si hay un empate
                else if (counterXO > 8)
                {
                    Console.WriteLine("Tie!");
                    endGame = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ComputerVsComputer()
        {
            Console.WriteLine("Enter the coordinates: (x,y)");
            ShowBoard();

            do
            {
                Thread.Sleep(1500);
                // Se busca un movimiento valido
                for (int i = 0; i < plays.Length; i++)
                {
                    coordinate = plays[random.Next(9)];
                    // Si el movimiento es valido sale del for
                    if (CheckMove(coordinate))
                    {
                       break;
                    }
                }

            } while (endGame);

            NewGame();
        }
    }
}
