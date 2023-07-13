using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTurnsPerPlayer = 5;
            string[] fieldWithX = new string[numberOfTurnsPerPlayer];
            string[] fieldWithO = new string[numberOfTurnsPerPlayer];
            string[,] fieldOfPlay = { { "1", "2", "3"}, { "4", "5", "6"}, { "7", "8", "9"} };
            int movesWereMade = 0;
            string[] winnigCombination = null;

            while (winnigCombination == null && movesWereMade < 9)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(fieldOfPlay[i, j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("------");
                }

                if (movesWereMade % 2 == 0)
                {
                    Console.WriteLine("Ход игрока 1 (Крестик): ");
                    fieldWithX[movesWereMade / 2] = NumberCheck();
                    if (fieldWithX[movesWereMade / 2] == "Ошибка")
                    {
                        Console.WriteLine("Были ведены не корректные данные, попробуйте вести число от 1 до 9");
                        continue;
                    }
                    if (fieldOfPlay[(Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) % 3] != "X" &&
                       fieldOfPlay[(Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) % 3] != "O")
                    {
                        fieldOfPlay[(Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithX[movesWereMade / 2]) - 1) % 3] = "X";
                        winnigCombination = WinCheck(fieldWithX);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Данная ячейка уже заполнена, попробуйте другую.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Ход игрока 2 (Нолик): ");
                    fieldWithO[movesWereMade / 2] = NumberCheck();
                    if (fieldWithO[movesWereMade / 2] == "Ошибка")
                    {
                        Console.WriteLine("Были ведены не корректные данные, попробуйте вести число от 1 до 9");
                        continue;
                    }
                    if (fieldOfPlay[(Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) % 3] != "X" &&
                       fieldOfPlay[(Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) % 3] != "O")
                    {
                        fieldOfPlay[(Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) / 3, (Convert.ToInt32(fieldWithO[movesWereMade / 2]) - 1) % 3] = "O";
                        winnigCombination = WinCheck(fieldWithO);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Данная ячейка уже заполнена, попробуйте другую.");
                        continue;
                    }
                    
                }

                movesWereMade++;

            }

            if (winnigCombination != null && movesWereMade % 2 == 0 && movesWereMade > 4 && movesWereMade < 9)
            {
                Console.WriteLine("Выиграл игрок 2");
                ShowWinningCombination(fieldOfPlay, fieldWithO);
            }
            else if (winnigCombination != null && movesWereMade % 2 == 1 && movesWereMade > 4 && movesWereMade < 9)
            {
                Console.WriteLine("Выиграл игрок 1");
                ShowWinningCombination(fieldOfPlay, fieldWithX);
            }
            else
            {
                Console.WriteLine("Ничья");
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

            Console.ReadLine();
        }
        /// <summary>
        /// Проверка выигрыша игрока.
        /// </summary>
        /// <param name="field">Поле</param>
        /// <returns></returns>
        static string[] WinCheck(string[] field)
        {
            List<string> winnigCombination = new List<string>(3);
            int numberOfTurnsPerPlayer = 5;
            int numberOfIdenticalCharactera = 0;
            int maxNumberOfIdenticalCharactera = 0;
            // Проверка вертикальных линий
            for (int i = 0; i < numberOfTurnsPerPlayer; i++)
            {
                for (int j = 0; j < numberOfTurnsPerPlayer; j++)
                {
                    if ((Convert.ToInt32(field[i]) - 1) % 3 == (Convert.ToInt32(field[j]) - 1) % 3 && field[j] != null && field[i] != null)
                    {
                        numberOfIdenticalCharactera++;
                        winnigCombination.Add(field[i]);
                    }
                }
                if (maxNumberOfIdenticalCharactera < numberOfIdenticalCharactera)
                {
                    maxNumberOfIdenticalCharactera = numberOfIdenticalCharactera;
                }
                //if (winnigCombination.Count() != 3)
                //{
                //    winnigCombination.Clear();
                //}
                numberOfIdenticalCharactera = 0;
            }
            if (maxNumberOfIdenticalCharactera > 2)
            {
                return winnigCombination.ToArray();
            }
            // Проверка горизонтальных линий
            maxNumberOfIdenticalCharactera = 0;
            for(int i = 0; i < numberOfTurnsPerPlayer; i++)
            {
                for (int j = 0;j < numberOfTurnsPerPlayer; j++)
                {
                    if ((Convert.ToInt32(field[i]) - 1) / 3 == (Convert.ToInt32(field[j]) - 1) / 3 && field[j] != null && field[i] != null)
                    {
                        numberOfIdenticalCharactera++;
                        winnigCombination.Add(field[i]);
                    }
                }
                if (maxNumberOfIdenticalCharactera < numberOfIdenticalCharactera)
                {
                    maxNumberOfIdenticalCharactera = numberOfIdenticalCharactera;
                }
                //if (winnigCombination.Count() != 3)
                //{
                //    winnigCombination.Clear();
                //}
                numberOfIdenticalCharactera = 0;
            }
            if (maxNumberOfIdenticalCharactera > 2)
            {
                return winnigCombination.ToArray();
            }
            

            return null;
        }

        static string NumberCheck()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0 && number < 10)
            {
                return number.ToString();
            }
            return "Ошибка";
        }
        static void ShowWinningCombination(string[,] fieldOfPlay, string[] winnigCombination)
        {
            for(int i = 0; i < 3; i++) 
            {
                for(int j = 0; j < 3; j++) 
                {
                    if (СheckElementInArray(winnigCombination, i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(fieldOfPlay[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(fieldOfPlay[i, j]);
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------");
            }


            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(fieldOfPlay[i, j] + "|");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("------");
            //}
        }
        static bool СheckElementInArray(string[] winnigCombination, int i, int j)
        {
            bool isElementInArray = false;
            for (int k = 0; k < winnigCombination.Length; k++)
            {
                if (Convert.ToInt32(winnigCombination[k]) == i * 3 + j + 1)
                {
                    isElementInArray = true;
                }
            }
            return isElementInArray;
        }
    }
}
