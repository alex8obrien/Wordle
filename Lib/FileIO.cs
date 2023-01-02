namespace Lib
{
    public class FileIO
    {
        /// <summary>This methods returns the number of lines in a file.</summary>
        /// <param name="filePath">It's the path of the file from the solution folder including the file extension</param>
        /// <returns>An integer of the number of lines in a file</returns>
        public static int TotalLines(string filePath)
        {
            filePath =  Directory.GetParent(Directory.GetCurrentDirectory().Split("\\bin")[0]) + "\\" +  filePath;
            using StreamReader reader = new(filePath);
            int count = 0;
            while (reader.ReadLine() != null) { count++; }
            return count;
        }

        /// <summary>It returns a string of a specific line in a file</summary>
        /// <param name="filePath">It's the path of the file from the solution folder including the file extension</param>
        /// <param name="lineNumber">The specific line you want returned</param>
        /// <returns>A line in a file as a string</returns>
        /// <exception cref="Exception">New exception - "Line not found"</exception>
        public static string LineAt(string filePath, int lineNumber)
        {
            filePath =  Directory.GetParent(Directory.GetCurrentDirectory().Split("\\bin")[0]) + "\\" +  filePath;
            return File.ReadLines(filePath).ElementAt(lineNumber) ?? throw new Exception("Line not found");
        }
    }
}