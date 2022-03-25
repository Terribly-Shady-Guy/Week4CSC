using Microsoft.AspNetCore.Mvc;

namespace Tyler_Kaufmann_Week_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcStDevApi : ControllerBase
    {

        [HttpPost(Name = "CalculateStDev")]
        public ActionResult<List<string>> PostStDev(List<int> data)
        {
            LogObject(data);
            data.Sort();

            List<int> childList = new List<int>();
            List<string> results = new List<string>();

            foreach (int number in data)
            {
                childList.Add(number);
                int childLength = childList.Count;

                if (childLength > 1)
                {
                    double stDev = CalcStDev(childList, childLength);
                    results.Add($"Elements: {childLength} Current Standard Deviation: {stDev}.");
                }
                else
                {
                    results.Add("List too small.");
                }
            }

            return results;
        }

        // Calculates Standard Deviation using Sqrt(Sum((x[i] - sampleMean)^2) / (N - 1)).
        private static double CalcStDev(List<int> data, int length)
        {
            double sampleMean = data.Average();
            double sum = data.Sum(num => Math.Pow(num - sampleMean, 2));
            return Math.Sqrt(sum / (length - 1));
        }

        private static void LogObject(List<int> data)
        {
            foreach (int num in data)
            {
                System.Diagnostics.Debug.WriteLine(num);
            }
        }
    }
}