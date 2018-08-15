using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Was.Domain.Areas.Word
{
    public class Cell
    {
        public Cell(int columnIndex, int rowIndex, string value)
        {
            Guard.StringNotNullOrEmpty(() => value);

            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            Value = value;
        }

        public int ColumnIndex { get; }
        public int RowIndex { get; }
        public string Value { get; }
    }
}