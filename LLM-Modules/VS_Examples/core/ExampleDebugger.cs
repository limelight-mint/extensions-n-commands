
namespace LLM.Examples.core
{
    internal class ExampleDebugger
    {
        public static void LogInfo(string info) => LogColorized(info, ConsoleColor.Yellow);
        public static void LogError(string info) => LogColorized(info, ConsoleColor.Red);
        public static void LogCringe(string info) => LogColorized(info, ConsoleColor.Magenta);
        public static void LogSuccess(string info) => LogColorized(info, ConsoleColor.Green);

        public static void LogColorized(string content, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public static int GetIntInput()
        {
            int input = 0;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                ExampleDebugger.LogError($"\n[ERROR]: \n{ex.Message}\nYou sure u passed a number, huh?");
            }
            return input;
        }
    }
}
