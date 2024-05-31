using LLM.Examples.core;
using System.Diagnostics;

namespace LLM.Examples._LiteCheckSummer_Example
{
    internal class LiteCheckSummerExample : BaseAwaitableExample
    {
        public LiteCheckSummerExample(int index) : base(index) { }

        public override async Task OnExampleShowed()
        {
            var currentPath = Directory.GetCurrentDirectory();
            var directoryToCheckSummer = Path.Combine(currentPath, "LLMCheckSummer");
            var fullPath = Path.Combine(directoryToCheckSummer, "LLMCheckSummer.exe");
            ExampleDebugger.LogCringe($"[STARTING] {fullPath}\n");
            ExampleDebugger.LogCringe($"[INPUT REQUIRED]\n Type 1 to see creation checsums example and 2 to see compare example");

            //no strategy or compose patterns, straightforward raw c# example:

            //1. creating a process to start (our cmd LLMCheckSummer)
            var process = new Process();

            //prepare our box with arguments that is empty for now
            string arguments = string.Empty;

            //ignore this part we are just check what u want to see (compare or creating a checksum)
            int userOperation = ExampleDebugger.GetIntInput();

            //2. get our arguments
            if (userOperation == 1) //if u chose create checksum
            {
                arguments = CallToCreateChecksum(currentPath);
            }
            else if(userOperation == 2) //if u chose compare checksum
            {
                arguments = CallToCompareChecksums(
                    Path.Combine(currentPath, "Compare_Files", "checksum1.txt"),
                    Path.Combine(currentPath, "Compare_Files", "checksum2.txt"),
                    "❤❤❤❤❤❤",
                    ":");
            } else return;

            //3. creating an info for startup execution with our arguments
            ProcessStartInfo startInfo = new ProcessStartInfo(fullPath, arguments);
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            //4. assigning our new process an info we just createad with LLMCheckSummer.exe path
            process.StartInfo = startInfo;

            //5. start the process
            process.Start();

            //6. get the raw result
            string result = process.StandardOutput.ReadToEnd();
            ExampleDebugger.LogSuccess($"[OUTPUT]: {result}");
        }

        private string CallToCreateChecksum(string pathToParse)
        {
            //Here is the creation of the command to create checksum file
            //Lets break it down!:
            //
            //1. '--compute' is the command what action to do ('--compare' is also an action)
            //2. 'pathToParse' is a Directory path (path to a folder not a file) so LLMCheckSummer could do a lookup
            //and weight up all the check sums in this folder your provide,
            //other example would be: 'C:\\Users\\user\\Documents\\GitHub\\LiteHasher'
            //3. ':' is a parser divider, which symbol or even a whole text would divide NAME:SUM_KEY values
            //4. 'checksum' is the name of the file that would be spawned in this directory (checksum.txt in our example)
            //other example would be: '!❤❤❤!' or '@' or ':DIVIDER_XD:', you got the idea

            //example with full paths:  $"--compute {pathToParse} : checksum ++fullPath";
            return $"--compute {pathToParse} : checksum";
        }

        private string CallToCompareChecksums(string firstPath, string secondPath, string firstSeparator, string secondSeparator)
        {
            //Here is the creation of the command to compare 2 checksum files with different separator
            //Lets break it down!:
            //
            //1. '--compare' is the command what action to do (currently compare 2 different files of checksums)
            //2. 'firstPath' is the first full path to the first file with checksum list
            //3. 'secondPath' is the second full path to the second file with ckecksum list
            //4. 'firstSeparator' is the divider between path and hash sum in firstPath file, if you leave it empty it will be ':'
            //5. 'secondSeparator' is the divider between path and hash sum in secondPath file, if you leave it empty it will be ':'
            return $"--compare {firstPath} {secondPath} {firstSeparator} {secondSeparator}";
        }

    }
}
