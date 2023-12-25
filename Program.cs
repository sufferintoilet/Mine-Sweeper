﻿using System;
using System.Collections.Generic;
using System.Text;

namespace mineText
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
        };
            int row = array.GetLength(0);
            int column = array.GetLength(1);

            string[,] mapReport = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    
                    if (array[i, j].Equals("*"))
                    {
                        mapReport[i, j] = "*";
                    }
                    else
                    {
                        int[,] NEIGHBOURS_ORDINATE = {
                        {i - 1, j - 1}, {i - 1, j}, {i - 1, j + 1},
                        {i, j - 1}, {i, j + 1},
                        {i + 1, j - 1}, {i + 1, j}, {i + 1, j + 1},};

                        int minesAround = 0;
                        int length = NEIGHBOURS_ORDINATE.GetLength(0);
                        for (int q = 0; q < length; q++)
                        {
                            int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[q, 1];
                            int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[q, 0];

                            bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0
                                    || xOrdinateOfNeighbour == column
                                    || yOrdinateOfNeighbour < 0
                                    || yOrdinateOfNeighbour == row;
                            if (isOutOfMapNeighbour)
                            {
                                continue;
                            }

                            bool isMineOwnerNeighbour = array[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                            if (isMineOwnerNeighbour)
                            {
                                minesAround++;
                            }
                        }

                        mapReport[i, j] = minesAround.ToString();
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < column; j++)
                {
                    String currentCellReport = mapReport[i, j];
                    Console.Write(currentCellReport);
                }
            }
            Console.ReadLine();
        }
    }
}
