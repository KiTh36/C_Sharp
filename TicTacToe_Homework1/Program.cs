// See https://aka.ms/new-console-template for more information

using System;

class TicTacToe
{
    static char[,] board;
    static int boardSize;
    static char emptySymbol = '_';

    static void Main()
    {
        Console.Write("Input the board size (e.g., 3): ");
        if (!int.TryParse(Console.ReadLine(), out boardSize)) boardSize = 3;

        board = new char[boardSize, boardSize];
        GenerateBoard();

        char currentPlayer = 'X'; 

        while (true)
        {
            Console.Clear();
            ShowBoard();
            Console.WriteLine($"Player {currentPlayer}'s turn.");

            PlayerMove(currentPlayer); 

            if (CheckStatus(currentPlayer))
            {
                Console.Clear();
                ShowBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                break;
            }

            if (IsDraw())
            {
                Console.Clear();
                ShowBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void GenerateBoard()
    {
        for (int i = 0; i < boardSize; i++)
            for (int j = 0; j < boardSize; j++)
                board[i, j] = emptySymbol;
    }

    static void ShowBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }

    static void PlayerMove(char symbol)
    {
        while (true)
        {
            Console.Write("Enter your move (row,col e.g. 0,0): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',');

          
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid format! Use row,col.");
                continue;
            }

            if (int.TryParse(parts[0], out int row) &&
                int.TryParse(parts[1], out int col) &&
                row >= 0 && row < boardSize &&
                col >= 0 && col < boardSize &&
                board[row, col] == emptySymbol)
            {
                board[row, col] = symbol;
                break;
            }
            else
            {
                Console.WriteLine("Invalid move! Cell is occupied or out of range.");
            }
        }
    }

    static bool CheckStatus(char symbol)
    {
        for (int i = 0; i < boardSize; i++)
        {
            bool rowWin = true;
            bool colWin = true;
            for (int j = 0; j < boardSize; j++)
            {
                if (board[i, j] != symbol) rowWin = false;
                if (board[j, i] != symbol) colWin = false;
            }
            if (rowWin || colWin) return true;
        }

        bool diag1 = true, diag2 = true;
        for (int i = 0; i < boardSize; i++)
        {
            if (board[i, i] != symbol) diag1 = false;
            if (board[i, boardSize - 1 - i] != symbol) diag2 = false;
        }
        return diag1 || diag2;
    }

    static bool IsDraw()
    {
        foreach (var cell in board)
            if (cell == emptySymbol) return false;
        return true;
    }
}