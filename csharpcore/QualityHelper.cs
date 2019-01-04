using System;

namespace csharpcore
{
    public class QualityHelper
    {
        public void IncrementItemQuality(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, 50);
        }

        public void DecrementItemQuality(Item item)
        {
            item.Quality = Math.Max(item.Quality - 1, 0);
        }

        public void ResetItemQuality(Item item)
        {
            item.Quality = 0;
        }
    }
}