using System.Text;

namespace Lab9
{
    /// <summary>
    /// Storehouse — класс для управления запасными частями в складе.
    /// </summary>
    public class Storehouse
    {
        List<PartsWarehouse> warehouseList = new List<PartsWarehouse>();

        public List<PartsWarehouse> WarehouseList
        {
            get => warehouseList;
            set => warehouseList = value;
        }

        /// <summary>
        /// Добавление новой запчасти в List.
        /// </summary>
        /// <param name="newPart">Новая деталь которую необходимо добавить, проверяется есть ли уже данный объект в List через проверку Id.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AddParts(PartsWarehouse newPart)
        {
            if (newPart is not null)
            {
                foreach (PartsWarehouse part in WarehouseList)
                {
                    if (part.Id.Equals(newPart.Id))
                    {
                        throw new ArgumentOutOfRangeException("This part is already in Storage!");
                    }
                }
                WarehouseList.Add(newPart);
            }
            else
            {
                Console.WriteLine(newPart);
                throw new ArgumentOutOfRangeException("This part is already in Storage!");
            }
        }

        /// <summary>
        /// Удаление запчасти из List.
        /// </summary>
        /// <param name="partToRemove">Деталь которую необходимо удалить.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemovePart(PartsWarehouse partToRemove)
        {
            if (partToRemove is not null && WarehouseList.Contains(partToRemove))
            {
                WarehouseList.Remove(partToRemove);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This part does not exist!");
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (PartsWarehouse part in WarehouseList)
            {
                str.Append(part + "\n");
            }
            return str.ToString();
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
