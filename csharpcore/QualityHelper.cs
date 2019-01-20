using System;

namespace csharpcore
{
    public class QualityHelper
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        public void IncrementItemQuality(Item item, int qualityChange = 1)
        {
            item.Quality = Math.Min(item.Quality + qualityChange, MaxQuality);
        }

        public void DecrementItemQuality(Item item, int qualityChange = 1)
        {
            item.Quality = Math.Max(item.Quality - qualityChange, MinQuality);
        }

        public void ResetItemQuality(Item item)
        {
            item.Quality = 0;
        }
    }
}