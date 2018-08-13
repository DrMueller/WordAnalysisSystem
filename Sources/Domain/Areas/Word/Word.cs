namespace Mmu.Was.Domain.Areas.Word
{
    public class Word
    {
        public Word(int startPosition, string text)
        {
            StartPosition = startPosition;
            Text = text;
        }

        public int StartPosition { get; }
        public string Text { get; }
    }
}