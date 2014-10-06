namespace MineSweeperGame
{
    using System;
    using System.Collections.Generic;
 
    public class Minesweeper
    {
        public class Player
        {
            private string name;
            private int points;

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }

            public Player()
            {
            }

            public Player(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        private static void Main()
        {
            string command = string.Empty;
            char[,] gameBoard = CreateGameBoard(); 
            char[,] gameBoardWithBombs = InsertBombs();
            int counter = 0;
            bool isDead = false;
            List<Player> Shampions = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool gameBoardNotDrawn = true;
            const int maxCount = 35;
            bool allBombsCleared = false;

            do
            {
                if (gameBoardNotDrawn)
                {
                    Console.WriteLine(
                        "Lets play “MineSweeper”. Try finding the fields with no mines on them.\n"
                        + "Command'top' shows the current ranking, 'restart' starts a new game, 'exit' exits the game!");
                    DrawBoardFrame(gameBoard);
                    gameBoardNotDrawn = false;
                }

                Console.Write("Specify row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= gameBoard.GetLength(0) && column <= gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(Shampions);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        gameBoardWithBombs= InsertBombs();
                        DrawBoardFrame(gameBoard);
                        isDead = false;
                        gameBoardNotDrawn = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye-Bye!");
                        break;
                    case "turn":
                        if (gameBoardWithBombs[row, column] != '*')
                        {
                            if (gameBoardWithBombs[row, column] == '-')
                            {
                                NextTurn(gameBoard, gameBoardWithBombs, row, column);
                                counter++;
                            }

                            if (maxCount == counter)
                            {
                                allBombsCleared = true;
                            }
                            else
                            {
                                DrawBoardFrame(gameBoard);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError. Invalid commmans!\n");
                        break;
                }

                if (isDead)
                {
                    DrawBoardFrame(gameBoardWithBombs);
                    Console.Write("\nHrrrrrr! You died heroicly with {0} points." + "Write down your nickname: ", counter);
                    string nickName = Console.ReadLine();
                    Player curretnPlayer = new Player(nickName, counter);
                    if (Shampions.Count < 5)
                    {
                        Shampions.Add(curretnPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < Shampions.Count; i++)
                        {
                            if (Shampions[i].Points < curretnPlayer.Points)
                            {
                                Shampions.Insert(i, curretnPlayer);
                                Shampions.RemoveAt(Shampions.Count - 1);
                                break;
                            }
                        }
                    }

                    Shampions.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    Shampions.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(Shampions);

                    gameBoard = CreateGameBoard();
                    gameBoardWithBombs = InsertBombs();
                    counter = 0;
                    isDead = false;
                    gameBoardNotDrawn = true;
                }

                if (allBombsCleared)
                {
                    Console.WriteLine("\nCONGRATULATONS! You opened 35 boxes without stepping on a minee.");
                    DrawBoardFrame(gameBoardWithBombs);
                    Console.WriteLine("Please write down your name in the champions list: ");
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, counter);
                    Shampions.Add(currentPlayer);
                    Ranking(Shampions);
                    gameBoard = CreateGameBoard();
                    gameBoardWithBombs = InsertBombs();
                    counter = 0;
                    allBombsCleared = false;
                    gameBoardNotDrawn = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - by SoftwareUniversity");
            Console.WriteLine("Thank you for playing.");
            Console.Read();
        }

        private static void Ranking(List<Player> playersPoints)
        {
            Console.WriteLine("\nPoints:");
            if (playersPoints.Count > 0)
            {
                for (int i = 0; i < playersPoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, playersPoints[i].Name, playersPoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No ranking available!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char numberOfBombs = CalculateNumberOfBombs(bombs, row, column);
            bombs[row, column] = numberOfBombs;
            field[row, column] = numberOfBombs;
        }

        private static void DrawBoardFrame(char[,] board)
        {
            int boardHeight = board.GetLength(0);
            int boardWidth = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardHeight; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardWidth; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            const int boardRows = 5;
            const int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] InsertBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameBoard = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameBoard[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int randomBomb = random.Next(50);
                if (!bombs.Contains(randomBomb))
                {
                    bombs.Add(randomBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int columnToInsert = bomb / columns;
                int rowToInsert = bomb % columns;
                if (rowToInsert == 0 && bomb != 0)
                {
                    columnToInsert--;
                    rowToInsert = columns;
                }
                else
                {
                    rowToInsert++;
                }

                gameBoard[columnToInsert, rowToInsert - 1] = '*';
            }

            return gameBoard;
        }

        private static void NumberOfBombs(char[,] gameBoard)
        {
            int row  = gameBoard.GetLength(0);
            int column = gameBoard.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (gameBoard[i, j] != '*')
                    {
                        char numberOfBombs = CalculateNumberOfBombs(gameBoard, i, j);
                        gameBoard[i, j] = numberOfBombs;
                    }
                }
            }
        }

        private static char CalculateNumberOfBombs(char[,] gameBoard, int rows, int columns)
        {
            int bombsCount = 0;
            int row = gameBoard.GetLength(0);
            int column = gameBoard.GetLength(1);

            if (rows - 1 >= 0)
            {
                if (gameBoard[rows - 1, columns] == '*')
                {
                    bombsCount++;
                }
            }

            if (rows + 1 < row)
            {
                if (gameBoard[rows + 1, columns] == '*')
                {
                    bombsCount++;
                }
            }

            if (columns - 1 >= 0)
            {
                if (gameBoard[rows, columns - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if (columns + 1 < column)
            {
                if (gameBoard[rows, columns + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (columns - 1 >= 0))
            {
                if (gameBoard[rows - 1, columns - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (columns + 1 < column))
            {
                if (gameBoard[rows - 1, columns + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows + 1 < row) && (columns - 1 >= 0))
            {
                if (gameBoard[rows + 1, columns - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((rows + 1 < row) && (columns + 1 < column))
            {
                if (gameBoard[rows + 1, columns + 1] == '*')
                {
                    bombsCount++;
                }
            }

            return char.Parse(bombsCount.ToString());
        }
    }
}