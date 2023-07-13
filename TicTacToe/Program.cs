using System.Threading.Channels;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] fieldOfPlay = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            bool isWin = false;
            int moveCounter = 0;
            string errMes = "";
            while (moveCounter < 9)
            {
                Console.Clear();
                for(int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(fieldOfPlay[i, j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("------");
                }
                if (errMes != "")
                {
                    Console.WriteLine(errMes);
                }
                errMes = "";
                Console.Write(moveCounter % 2 == 0 ? "Ход игрока 1 (Крестик): " : "Ход игрока 2 (Нолик): ");
                string playerTurn = Console.ReadLine();
                if (int.TryParse(playerTurn, out int result))
                {
                    if (!(result > 0 && result < 10)) 
                    {
                        errMes = "Поробуйте ввести число от 1 до 9";
                        continue;
                    }
                }
                else
                {
                    errMes = "Поробуйте ввести число от 1 до 9";
                    continue;
                }
                
                if (fieldOfPlay[(Convert.ToInt32(playerTurn) - 1) / 3, (Convert.ToInt32(playerTurn) - 1) % 3] == "X" || 
                    fieldOfPlay[(Convert.ToInt32(playerTurn) - 1) / 3, (Convert.ToInt32(playerTurn) - 1) % 3] == "O")
                {
                    errMes = "Данная ячейка уже заполнена, попробуйте другую." ;
                    continue;
                }
                else
                {
                    fieldOfPlay[(Convert.ToInt32(playerTurn) - 1)/ 3, (Convert.ToInt32(playerTurn) - 1) % 3] = moveCounter % 2 == 0 ? "X" : "O";
                }
                moveCounter++;
                string[] winningCombination = new string[3]; 
                bool isGreen = false;
                if (PlayerWinCheck(fieldOfPlay) != null && moveCounter < 10)
                {
                    
                    Console.Clear();
                    Console.WriteLine(moveCounter % 2 == 0 ? "Победа игрока 2 (Нолик): " : "Победа игрока 1 (Крестик): ");
                    Console.WriteLine();
                    winningCombination = PlayerWinCheck(fieldOfPlay);
                    for (int i = 0;i < 3; i++)
                    {
                        for (int j = 0;j < 3; j++)
                        {
                            for (int k = 0;k < 3; k++)
                            {
                                if ((3 * i + j + 1).ToString() == winningCombination[k])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(fieldOfPlay[i, j]);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("|");
                                    isGreen = true;
                                }
                            }
                            if (!isGreen)
                            {
                                Console.Write(fieldOfPlay[i, j] + "|");
                            }
                            isGreen = false;
                        }
                        Console.WriteLine();
                        Console.WriteLine("------");
                    }
                    isWin = true;
                    break;
                }
            }
            if (!isWin)
            {
                Console.Clear();
                Console.WriteLine("Ничья");
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(fieldOfPlay[i, j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("------");
                }
            }

        }
        /// <summary>
        /// Проверка, что игрок выиграл.
        /// </summary>
        /// <param name="fieldOfPlay"></param>
        /// <returns>Возращает победную комбинацию полей.</returns>
        static string[] PlayerWinCheck(string[,] fieldOfPlay)
        {
            string[] winningCombination = new string[3];    
            for (int i = 0; i < 3; i++)
            {
                // проверка 
                if (fieldOfPlay[0, i] == fieldOfPlay[1, i] && fieldOfPlay[1, i] == fieldOfPlay[2, i])
                {
                    winningCombination[0] = (3 * 0 + i + 1).ToString();
                    winningCombination[1] = (3 * 1 + i + 1).ToString();
                    winningCombination[2] = (3 * 2 + i + 1).ToString();
                    return winningCombination;
                }
                // проверка горизонтальной линии
                else if (fieldOfPlay[i, 0] == fieldOfPlay[i, 1] && fieldOfPlay[i, 1] == fieldOfPlay[i, 2]){
                    winningCombination[0] = (3 * i + 0 + 1).ToString();
                    winningCombination[1] = (3 * i + 1 + 1).ToString();
                    winningCombination[2] = (3 * i + 2 + 1).ToString();
                    return winningCombination;
                }
                else if (fieldOfPlay[0, 0] == fieldOfPlay[1, 1] && fieldOfPlay[0, 0] == fieldOfPlay[2, 2])
                {
                    winningCombination[0] = "1";
                    winningCombination[1] = "5";
                    winningCombination[2] = "9";
                    return winningCombination;
                }
                else if (fieldOfPlay[2, 0] == fieldOfPlay[1, 1] && fieldOfPlay[2, 0] == fieldOfPlay[0, 2])
                {
                    winningCombination[0] = "3";
                    winningCombination[1] = "5";
                    winningCombination[2] = "7";
                    return winningCombination;
                }
            }
            return null;
        }
    }
}