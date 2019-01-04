using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        QualityHelper QualityHelper;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            this.QualityHelper = new QualityHelper();
        }

        public void UpdateQuality()
        {
            foreach (Item item in this.Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    this.QualityHelper.DecrementItemQuality(item);
                }
                else
                {
                    this.QualityHelper.IncrementItemQuality(item);
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            this.QualityHelper.IncrementItemQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            this.QualityHelper.IncrementItemQuality(item);
                        }
                    }
                }

                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        this.QualityHelper.IncrementItemQuality(item);
                    }
                    else
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                                this.QualityHelper.DecrementItemQuality(item);
                        }
                        else
                        {
                            this.QualityHelper.ResetItemQuality(item);
                        }
                    }
                }
            }
        }
    }
}
