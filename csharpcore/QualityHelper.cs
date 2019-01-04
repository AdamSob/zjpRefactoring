using System;

namespace csharpcore
{
    public class QualityHelper
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        public void IncrementItemQuality(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, MaxQuality);
        }

        public void DecrementItemQuality(Item item)
        {
            item.Quality = Math.Max(item.Quality - 1, MinQuality);
        }

        public void ResetItemQuality(Item item)
        {
            item.Quality = 0;
        }
    }
}