using Lab9;
using Lab9.RandomPartsWarehouse;
using static Lab9.SortParts;

internal class Program
{
    private static void Main(string[] args)
    {
        Storehouse store = new Storehouse();

        for (int i = 0; i < 5; i++)
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


        CompareDelegate compareDelegate2 = (left, right) => left.Quantity < right.Quantity;

        //Стандартный делегат
        //Sort(store, OrderByDescendingNameLeft);

        //Лямбда выражение вместо делегата
        //Sort(store, compareDelegate2);
        SortPartsAnonymDelegate.SortOrderByNameLeft(store);
        Console.WriteLine("Sorted parts -------------------------------------------------");
        Console.WriteLine(store);
    }
}