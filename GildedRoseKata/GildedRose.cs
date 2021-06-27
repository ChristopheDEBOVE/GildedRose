using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var t in _items)
            {
                if (t.Name == SulfurasHandOfRagnaros)
                    continue;

                ANewDay(t);

                switch (t.Name)
                {
                    case AgedBrie:
                        UpdateAgedBrie(t);
                        break;
                    case BackstagePassesToATafkal80EtcConcert:
                        UpdateBackStageConcert(t);
                        break;
                    default:
                        UpdateCommonItem(t);
                        break;
                }
            }
        }

        private static void ANewDay(Item t)
        {
            t.SellIn--;
        }

        private static bool IsExpired(Item t)
        {
            return t.SellIn < 0;
        }

        private static void UpdateBackStageConcert(Item t)
        {
            if (IsExpired(t))
            {
                t.Quality = 0;
                return;
            }

            IncreaseQuality(t);
            if (t.SellIn < 10) IncreaseQuality(t);

            if (t.SellIn < 5) IncreaseQuality(t);
        }

        private static void UpdateAgedBrie(Item t)
        {
            IncreaseQuality(t);
            if (IsExpired(t))
                IncreaseQuality(t);
        }

        private static void UpdateCommonItem(Item t)
        {
            DecreaseQuality(t);
            if (IsExpired(t)) DecreaseQuality(t);
        }

        private static void IncreaseQuality(Item t)
        {
            if (t.Quality < 50) t.Quality++;
        }

        private static void DecreaseQuality(Item t)
        {
            if (t.Quality > 0) t.Quality--;
        }
    }
}