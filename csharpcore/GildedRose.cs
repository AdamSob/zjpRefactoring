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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.QualityHelper.DecrementItemQuality(Items[i]);
                    }
                }
                else
                {
                    this.QualityHelper.IncrementItemQuality(Items[i]);
                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            this.QualityHelper.IncrementItemQuality(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            this.QualityHelper.IncrementItemQuality(Items[i]);
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                this.QualityHelper.DecrementItemQuality(Items[i]);
                            }
                        }
                        else
                        {
                            this.QualityHelper.ResetItemQuality(Items[i]);
                        }
                    }
                    else
                    {
                        this.QualityHelper.IncrementItemQuality(Items[i]);
                    }
                }
            }
        }
    }
}
