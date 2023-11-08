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
                        (storehouse.WarehouseList[j], storehouse.WarehouseList[j + 1]) = (storehouse.WarehouseList[j+1], storehouse.WarehouseList[j]);
                    }
                }
            }
        }
    }
}
