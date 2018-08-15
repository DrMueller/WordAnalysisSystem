namespace Mmu.Was.Domain.Areas.Word
{
    public class Shape : IElementWithCaption
    {
        public Shape(string captionText) => CaptionText = captionText;

        public string CaptionText { get; }
    }
}