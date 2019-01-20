using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class RuleManager
    {
        Dictionary<string, Action<Item>> QualityRuleMatcher;
        QualityHelper QualityHelper;
        private const int StandardQualityChange = 1;
        private const int AfterSellinDecrement = 2;

        public RuleManager()
        {
            this.QualityHelper = new QualityHelper();
            this.QualityRuleMatcher = new Dictionary<string, Action<Item>>();
            this.QualityRuleMatcher["Aged Brie"] = AgedBrieRules;
            this.QualityRuleMatcher["Sulfuras, Hand of Ragnaros"] = SulfurasRules;
            this.QualityRuleMatcher["Backstage passes to a TAFKAL80ETC concert"] = BackstagePassRules;
            this.QualityRuleMatcher["Conjured Mana Cake"] = ConjuredRules;
        }

        public void ExecuteRules(Item item)
        {
            this.ManageSellin(item);
            if (QualityRuleMatcher.ContainsKey(item.Name))
            {
                this.QualityRuleMatcher[item.Name].Invoke(item);
            }
            else
            {
                this.DefaultRule(item);
            }
        }

        private void ManageSellin(Item item)
        {
            if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn -= 1;
            }
        }

        private void AgedBrieRules(Item item)
        {
            const int AfterSellInChange = 2;
            int qualityChange = item.SellIn < 0 ? AfterSellInChange : StandardQualityChange;
            this.QualityHelper.IncrementItemQuality(item, qualityChange);
        }

        private void SulfurasRules(Item item)
        {
            // nothing to do for sulfuras
        }

        private void BackstagePassRules(Item item)
        {
            const int AfterSellIn10 = 10;
            const int AfterSellIn5 = 5;
            int qualityChange = StandardQualityChange;
            if (item.SellIn < AfterSellIn5)
            {
                qualityChange = 3;
            }
            else if (item.SellIn < AfterSellIn10)
            {
                qualityChange = 2;
            }
            if (item.SellIn < 0)
            {
                this.QualityHelper.ResetItemQuality(item);
            }
            else
            {
                this.QualityHelper.IncrementItemQuality(item, qualityChange);
            }
        }

        private void DefaultRule(Item item)
        {
            int qualityChange = item.SellIn < 0 ? AfterSellinDecrement : StandardQualityChange;
            this.QualityHelper.DecrementItemQuality(item, qualityChange);
        }

        private void ConjuredRules(Item item)
        {
            int qualityChange = item.SellIn < 0 ? AfterSellinDecrement * 2 : StandardQualityChange * 2;
            this.QualityHelper.DecrementItemQuality(item, qualityChange);
        }
    }
}