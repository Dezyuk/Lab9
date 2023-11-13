using Lab9;
using Lab9.RandomPartsWarehouse;
using static Lab9.SortParts;

internal class Program
{
    private static void Main(string[] args)
    {
        Storehouse store = new Storehouse();

        for (int i = 0; i < 50; i++)
        {
            store.AddParts(RandomParts.CreateParts());
        }
        Console.WriteLine(store);
        //Console.WriteLine("--------------------------------------------------");
        //store.RemovePart(part1);

        //Console.WriteLine(store);

        //string fileNameJSON = "Parts.json";
        //string fileNameBinary = "Parts.bin";

        //FileManager.SerializationJSON(store, fileNameJSON);
        //FileManager.SerializationBinary(store, fileNameBinary);

        //Storehouse store2 = FileManager.DeserializationJSON(fileNameJSON);
        //Console.WriteLine("Read from JSON\n--------------------------------------------------\n");
        //Console.WriteLine(store2);

        //Storehouse store3 = FileManager.DeserializationBinary(fileNameBinary);
        //Console.WriteLine("Read from Binary\n--------------------------------------------------\n");
        //Console.WriteLine(store3);


        //CompareDelegate compareDelegate2 = (left, right) => left.Quantity < right.Quantity;


        //Использование лямбда-выражения
        Sort(store, (left, right) => left.Price > right.Price);
        Console.WriteLine("Sorted parts -------------------------------------------------");
        Console.WriteLine(store);

        CompareDelegate orderByNameLeft = delegate (PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
        };
        Console.WriteLine("Sorted parts -------------------------------------------------");
        Console.WriteLine(store);

        //Использование анонимной функции
        Sort(store, orderByNameLeft);

        //Стандартный делегат
        Sort(store, OrderByQuantityLeft);
        Console.WriteLine("Sorted parts -------------------------------------------------");
        Console.WriteLine(store);

        //Стандартный делегат
        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store2 = FilterParts.Search(store, FilterParts.FilterPriceLower, 2500);
        Console.WriteLine(store2);


        FilterParts.SearchDelegate searchQuantityLower = delegate (PartsWarehouse part, double searchValue)
        {
            return part.Quantity < searchValue;
        };

        //Использование анонимной функции
        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store3 = FilterParts.Search(store, searchQuantityLower, 10);
        Console.WriteLine(store3);

        //Использование лямбда-выражения
        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store4 = FilterParts.Search(store, (part, searchValue) => part.Quantity > searchValue, 10);
        Console.WriteLine(store4);
    }
}