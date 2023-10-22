using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    public static class YieldStatement
    {

        public static void RunSample()
        {
            var result = OddNumbers(new[] { 1, 2, 3, 4, 5, 6, 7, 8});
            Console.WriteLine(string.Join(",", result));
        }
        static IEnumerable<int> OddNumbers(int[] nums)
        {
            foreach (int num in nums)
            {
                if (num % 2 == 0) continue;
                yield return num;
            }
        }

    }

}
