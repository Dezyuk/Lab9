﻿using Lab9;
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


        CompareDelegate orderByNameLeft = delegate (PartsWarehouse left, PartsWarehouse right)
        {
            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
        };

        //Использование анонимной функции
        Sort(store, orderByNameLeft);

        //Стандартный делегат
        Sort(store, OrderByQuantityLeft);
        Console.WriteLine("Sorted parts -------------------------------------------------");
        Console.WriteLine(store);


        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store2 = FilterParts.Search(store, FilterParts.FilterPriceLover, 2500);
        Console.WriteLine(store2);


        FilterParts.SearchDelegate searchQuantityLover = delegate (PartsWarehouse part, double searchValue)
        {
            return part.Quantity < searchValue;
        };

        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store3 = FilterParts.Search(store, searchQuantityLover, 10);
        Console.WriteLine(store3);


        Console.WriteLine("Filtered parts -------------------------------------------------");
        Storehouse store4 = FilterParts.Search(store, (part, searchValue) => part.Quantity > searchValue, 10);
        Console.WriteLine(store4);
    }
}