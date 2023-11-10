using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class SortParts
    {
        public delegate bool CompareDelegate(PartsWarehouse left, PartsWarehouse right);


        public static void Sort(Storehouse storehouse, CompareDelegate compareDelegate)
        {
            for (int i = 0; i < storehouse.WarehouseList.LongCount() - 1; i++)
            {
                for (int j = 0; j < storehouse.WarehouseList.LongCount() - 1; j++)
                {
                    if (compareDelegate(storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]))
                    {
                        (storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]) = (storehouse.WarehouseList[j + 1], storehouse.WarehouseList[j]);
                    }

                }
            }
        }

        public static bool OrderByNameLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
        }
        public static bool OrderByDescendingNameLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) < 0;
        }


        public static bool OrderByIdLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Id, right.Id, StringComparison.Ordinal) > 0;
        }
        public static bool OrderByDescendingIdLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Id, right.Id, StringComparison.Ordinal) < 0;
        }


        public static bool OrderByPriceLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return left.Price > right.Price;
        }
        public static bool OrderByDescendingPriceLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return left.Price < right.Price;
        }


        public static bool OrderByQuantityLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return left.Quantity > right.Quantity;
        }
        public static bool OrderByDescendingQuantityLeft(PartsWarehouse left, PartsWarehouse right)
        {
            return left.Quantity < right.Quantity;
        }


    }
}
