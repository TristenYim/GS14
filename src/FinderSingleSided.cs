public class FinderSingleSided : LevenshteinPathFinder {
    public override List<LinkedList<int>> GeneratePaths(int wordIndex1, int wordIndex2, LevenshteinDatabase database) {
        if (wordIndex1 == wordIndex2) {
            List<LinkedList<int>> path = new List<LinkedList<int>>();
            LinkedList<int> pathList = new LinkedList<int>();
            pathList.AddFirst(wordIndex1);
            path.Add(new LinkedList<int>(pathList));
            return path;
        }
        LevenshteinGraph g = new LevenshteinGraph(wordIndex1);
        while (true) {
            bool generateNewOuterSucceeded = g.GenerateNewOuter(database);
            if (PRINT_EXTRA) {
                Console.WriteLine("Outer: " + g.OuterCount);
                Console.WriteLine("Searched: " + g.SearchedCount);
            }

            if (!generateNewOuterSucceeded) {
                return null;
            }
            
            if (g.OuterContains(wordIndex2)) {
                return g.AllPathsBetween(wordIndex1, wordIndex2, false);
            }
        }
    }
}
