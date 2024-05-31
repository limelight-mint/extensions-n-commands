using System.Diagnostics;

namespace LLM.Examples.core
{
    internal class ForceQuit : BaseAwaitableExample
    {
        public ForceQuit(int index = -1) : base(index) { }

        public override Task OnExampleShowed()
        {
            var process = Process.GetCurrentProcess();
            process?.Kill();
            process?.Close();
            return Task.CompletedTask;
        }
    }
}
