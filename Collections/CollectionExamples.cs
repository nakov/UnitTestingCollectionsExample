using System;

namespace Collections
{
    class CollectionExamples
    {
        static void Main()
        {
            Collection<int> nums = new Collection<int>();
            Console.WriteLine(nums);
            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");

            nums = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });
            Console.WriteLine(nums);
            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");

            nums.Add(60);
            Console.WriteLine(nums);

            var removedItem = nums.RemoveAt(0);
            Console.WriteLine("Removed: {0}", removedItem);
            Console.WriteLine(nums);

            nums.RemoveAt(4);
            Console.WriteLine(nums);

            nums.Exchange(0, 1);
            Console.WriteLine(nums);

            for (int i = 1; i <= 20; i++)
                nums.Add(i);
            Console.WriteLine(nums);

            nums.InsertAt(0, 10);
            nums.InsertAt(1, 15);
            Console.WriteLine(nums);
            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");
        }
    }
}
