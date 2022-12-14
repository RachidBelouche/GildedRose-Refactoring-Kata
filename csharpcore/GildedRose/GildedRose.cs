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

            if (item.SellIn < 0)
                item.Quality = item.Quality - item.Quality;
            if (item.SellIn < 0 && item.Quality > 0)
            {

                item.Quality = item.Quality - 1;

            }
        }

        private void UpdateConjured(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
                item.Quality = item.Quality - item.Quality;
            if (item.SellIn < 0 && item.Quality > 0)
            {

                item.Quality = item.Quality - 2;

            }
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrie(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstage(item);
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSulfuras(item);
                }
                else if (item.Name == "Conjured Mana Cake")
                {
                    UpdateConjured(item);
                }
                else
                {
                    UpdateTheRest(item);
                }
            }
            return;
        }
    }
}
