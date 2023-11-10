using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab9.SortParts;

namespace Lab9
{
    public class SortPartsAnonymDelegate
    {
        public delegate bool CompareAnonymDelegate(PartsWarehouse left, PartsWarehouse right);
        public static void SortOrderByNameLeft(Storehouse storehouse)
        {
            for (int i = 0; i < storehouse.WarehouseList.LongCount() - 1; i++)
            {
                for (int j = 0; j < storehouse.WarehouseList.LongCount() - 1; j++)
                {
                    if (orderByNameLeft(storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]))
                    {
                        (storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]) = (storehouse.WarehouseList[j + 1], storehouse.WarehouseList[j]);
                    }
                }
            }
        }
        public static CompareAnonymDelegate orderByNameLeft = delegate (PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
        };
    }
}
