using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    public class StringInterpolationSamples
    {
        public static void RunSamples()
        {
            PatterMatching();
            RawString();
        }

        #region C# 11
        internal static void PatterMatching()
        {
            var scoreList = new int[] { 95, 85, 75, 65, 25, 0 };
            foreach (var safetyScore in scoreList)
            {
                string message = $"The usage policy for {safetyScore} is {safetyScore switch
                {
                    > 90 => "Unlimited usage",
                    > 80 => "General usage, with daily safety check",
                    > 70 => "Issues must be addressed within 1 week",
                    > 50 => "Issues must be addressed within 1 day",
                    _ => "Issues must be addressed before continued use",
                }}";
                Console.WriteLine(message);
            }
        }

        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals
        // Raw string literals are enclosed in a minimum of three double quotation marks ("""):
        internal static void RawString()
        {
            int X = 2;
            int Y = 3;

            var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";

            Console.WriteLine(pointMessage);

            var message = """
                    "This is a very important message."
                    """;
            Console.WriteLine(message);
            // output: "This is a very important message."
        }
        #endregion
    }
}
