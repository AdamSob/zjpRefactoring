using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void IncrementItemQuality(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, 50);
        }

        private void DecrementItemQuality(Item item)
        {
            item.Quality = Math.Max(item.Quality - 1, 0);
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.DecrementItemQuality(Items[i]);
                    }
                }
                else
                {
                    this.IncrementItemQuality(Items[i]);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            this.IncrementItemQuality(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            this.IncrementItemQuality(Items[i]);
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
                                this.DecrementItemQuality(Items[i]);
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        this.IncrementItemQuality(Items[i]);
                    }
                }
            }
        }
    }
}
