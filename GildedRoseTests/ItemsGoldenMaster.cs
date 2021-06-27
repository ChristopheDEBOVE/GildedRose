using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemsGoldenMaster
    {
        public readonly IReadOnlyCollection<(Item, Item)> Items;

        public ItemsGoldenMaster(IList<Item> items)
        {
            Items = items.Select(item => (item, Clone(item))).ToArray();
        }

        public IReadOnlyCollection<Item> List1 => Items.Select(a => a.Item1).ToList();
        public IReadOnlyCollection<Item> List2 => Items.Select(a => a.Item2).ToList();

        private Item Clone(Item i)
        {
            return new()
            {
                Name = i.Name,
                Quality = i.Quality,
                SellIn = i.SellIn
            };
        }
    }
}