namespace Problem2.AreasInMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class EntryPoint
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static Dictionary<char, int> areas;

        public static void Main()
        {
            matrix = new char[,]
            {
                {'a', 'a', 'c', 'c', 'c', 'a', 'a', 'c'},
                {'b', 'a', 'a', 'a', 'a', 'c', 'c', 'c'},
                {'b', 'a', 'a', 'b', 'a', 'c', 'c', 'c'},
                {'b', 'b', 'd', 'a', 'a', 'c', 'c', 'c'},
                {'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c'},
                {'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c'}
            };

            visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            areas = new Dictionary<char, int>();
            TraverseAndMarkConnectedCells();
        }

        static void TraverseAndMarkConnectedCells()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        MarkConnectedArea(row, col, matrix[row, col]);
                        if (!areas.ContainsKey(matrix[row, col]))
                        {
                            areas.Add(matrix[row, col], 1);
                        }
                        else
                        {
                            areas[matrix[row, col]]++;
                        }
                    }
                }
            }

            Console.WriteLine("Areas: {0}", areas.Sum(a => a.Value));
            var areasSorted = areas.OrderBy(a => a.Key);
            foreach (var area in areasSorted)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }
        }

        static void MarkConnectedArea(int row,
                                      int col,
                                      char areaCurrentValue)
        {
            if (!IsValidPosition(row, col))
            {
                return;
            }

            if (matrix[row, col] != areaCurrentValue)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            MarkConnectedArea(row, col + 1, areaCurrentValue); // right
            MarkConnectedArea(row + 1, col, areaCurrentValue); // down
            MarkConnectedArea(row, col - 1, areaCurrentValue); // left
            MarkConnectedArea(row - 1, col, areaCurrentValue); // up
        }

        static bool IsValidPosition(int row, int col)
        {
            bool validRowPosition = row >= 0 &&
                row < matrix.GetLength(0);

            bool validColPosition = col >= 0 &&
                col < matrix.GetLength(1);

            return validRowPosition && validColPosition;
        }
    }
}
