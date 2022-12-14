using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void UpdateAgedBrie(Item item)
        {
            if (item.SellIn >= 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void UpdateBackstage(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn >= 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void UpdateSulfuras(Item item)
        {
            if (item.SellIn >= 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 0)
                item.Quality = item.Quality - item.Quality;
        }

        private void UpdateTheRest(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn >= 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 0)
                item.Quality = item.Quality - item.Quality;
            if (item.SellIn < 0 && item.Quality > 0)
            {

                item.Quality = item.Quality - 1;

            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Aged Brie")
                {
                    UpdateAgedBrie(Items[i]);
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstage(Items[i]);
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSulfuras(Items[i]);
                }
                else if (Items[i].Name == "Conjured Mana Cake")
                {

                }
                else
                {
                    UpdateTheRest(Items[i]);
                }
            }
            return;
        }
    }
}
