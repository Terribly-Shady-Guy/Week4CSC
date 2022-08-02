namespace Tyler_Kaufmann_Week_3
{
    public class DebugLogger
    {
        public static void LogObject(List<int> data)
        {
            foreach (int num in data)
            {
                System.Diagnostics.Debug.WriteLine(num);
            }
        }
    }
}
