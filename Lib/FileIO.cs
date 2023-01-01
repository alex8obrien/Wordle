namespace Lib
{
    public class FileIO
    {
        public static int TotalLines(string filePath)
        {
            using StreamReader r = new(filePath);
            int count = 0;
            while (r.ReadLine() != null) { count++; }
            return count;
        }
    }
}