﻿namespace Lab9
{
    public class FilterParts
    {
        public delegate bool SearchDelegate(PartsWarehouse part, double searchValue);

        /// <summary>
        /// Фильтрация по значению
        /// </summary>
        /// <param name="parts">Список деталей</param>
        /// <param name="searchDelegate">Делегат</param>
        /// <param name="searchValue">Значение</param>
        /// <returns>Storehouse</returns>
        public static Storehouse Search(Storehouse parts, SearchDelegate searchDelegate, double searchValue)
        {
            Storehouse tempStorehouse = new Storehouse();
            for (int i = 0; i < parts.WarehouseList.LongCount(); i++)
            {
                if (searchDelegate(parts.WarehouseList[i], searchValue))
                {
                    tempStorehouse.AddParts(parts.WarehouseList[i]);
                }
            }
            return tempStorehouse;
        }

        public static bool FilterPriceLower(PartsWarehouse part, double value)
        {
            return part.Price < value;
        }
        public static bool FilterPriceHigher(PartsWarehouse part, double value)
        {
            return part.Price > value;
        }
    }
}
