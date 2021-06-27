using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class GildedRoseUnitTest
    {
        private readonly ItemsGoldenMaster _goodEnougthItemCollectionToCoverAllPathes = new(new List<Item>
        {
            new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        });

        [Fact]
        public void NoRegressionTest()
        {
            var goldenMaster = new GildedRoseGoldenMaster(_goodEnougthItemCollectionToCoverAllPathes.List1.ToList());
            var sut = new GildedRose(_goodEnougthItemCollectionToCoverAllPathes.List2.ToList());

            for (var i = 0; i < 7; i++)
            {
                sut.UpdateQuality();
                goldenMaster.UpdateQuality();

                foreach (var pair in _goodEnougthItemCollectionToCoverAllPathes.Items)
                    pair.Item1.Should().BeEquivalentTo(pair.Item2);
            }
        }
    }
}