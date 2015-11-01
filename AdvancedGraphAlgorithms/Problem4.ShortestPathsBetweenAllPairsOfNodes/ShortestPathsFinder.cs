namespace Problem4.ShortestPathsBetweenAllPairsOfNodes
{
    public static class ShortestPathsFinder
    {
        public static int[,] FindShortestPaths(int[,] distances)
        {
            var max = int.MaxValue;
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(0); j++)
                {
                    for (int k = 0; k < distances.GetLength(0); k++)
                    {
                        if (distances[i, k] == max ||
                            distances[k, j] == max)
                        {
                            continue;
                        }

                        if (distances[i, j] > distances[i, k] + distances[k, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            return distances;
        }
    }
}
