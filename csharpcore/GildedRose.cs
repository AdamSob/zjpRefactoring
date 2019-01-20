using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        RuleManager RuleManager;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            this.RuleManager = new RuleManager();
        }

        public void UpdateQuality()
        {
            foreach (Item item in this.Items)
            {
                this.RuleManager.ExecuteRules(item);
            }
        }
    }
}
