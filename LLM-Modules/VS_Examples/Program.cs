using LLM.Examples.core;
using LLM.Examples._LiteCheckSummer_Example;

namespace LLM.Examples
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            List<IExample> examples = CreateExamples();
            
            while(true)
            {
                ExampleDebugger.LogInfo("\n> Type 1, 2, 3 etc. number with an example output you want to see (by folder number)\nscripts will be loaded corresponding to the number of folder");
                ExampleDebugger.LogCringe("\nOr send -1 to quit");

                int input = GetInputFromUser();

                foreach (var example in examples)
                {
                    await example.ShowExample(input);
                }
            }
        }

        private static List<IExample> CreateExamples()
        {
            return new List<IExample>()
            {
                new ForceQuit(-1),

                new LiteCheckSummerExample(1),
            };
        }

        private static int GetInputFromUser() => ExampleDebugger.GetIntInput();
    }
}