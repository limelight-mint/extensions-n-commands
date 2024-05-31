
namespace LLM.Examples.core
{
    abstract class BaseAwaitableExample : IExample
    {
        public readonly int CorrespondingIndex = 0;

        public BaseAwaitableExample(int correspondingIndex)
        {
            CorrespondingIndex = correspondingIndex;
        }

        public Task ShowExample(int index)
        {
            if (index != CorrespondingIndex) return Task.CompletedTask;

            return OnExampleShowed();
        }

        public abstract Task OnExampleShowed();
    }
}
