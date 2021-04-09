using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class CollectionsTests
    {
        [Test]
        public void Test_Collections_EmptyConstructor()
        {
            var nums = new Collection<int>();
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collections_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collections_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(10, 20, 30);
            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 30]"));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collections_Add()
        {
            var nums = new Collection<int>(10, 20, 30);
            nums.Add(40);
            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 30, 40]"));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collections_AddWithGrow()
        {
            // Arrange
            var nums = new Collection<int>(10, 20, 30);
            int oldCapacity = nums.Capacity;

            // Act
            for (int i = 1; i <= 50; i++)
                nums.Add(i);
            
            // Assert
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            string expectedNums =
                "[10, 20, 30, " +
                string.Join(", ", Enumerable.Range(1, 50)) +
                "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
        }

        [Test]
        public void Test_Collections_AddRange()
        {
            var names = new Collection<string>("Peter", "Maria");
            names.AddRange("Steve", "Kate", "Jordan");
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria, Steve, Kate, Jordan]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collections_GetByIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            var item0 = names[0];
            Assert.That(item0, Is.EqualTo("Peter"));
            var item1 = names[1];
            Assert.That(item1, Is.EqualTo("Maria"));
        }

        [Test]
        public void Test_Collections_GetByInvalidIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            Assert.That(() => { var name = names[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria]"));
        }

        [Test]
        public void Test_Collections_SetByIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            names[0] = "Steve";
            names[1] = "Mike";
            Assert.That(names.ToString(), Is.EqualTo("[Steve, Mike]"));
        }

        [Test]
        public void Test_Collections_SetByInvalidIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            Assert.That(() => { names[-1] = "new item"; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names[-2] = "new item"; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names[500] = "new item"; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria]"));
        }

        [Test]
        public void Test_Collections_AddRangeWithGrow()
        {
            var nums = new Collection<int>(1, 2);
            int oldCapacity = nums.Capacity;
            nums.AddRange(Enumerable.Range(1000, 2000).ToArray());
            string expectedNums =
                "[1, 2, " +
                string.Join(", ", Enumerable.Range(1000, 2000)) +
                "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collections_InsertAtStart()
        {
            var names = new Collection<string>("Peter", "Maria");
            names.InsertAt(0, "Steve");
            Assert.That(names.ToString(), Is.EqualTo("[Steve, Peter, Maria]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collections_InsertAtEnd()
        {
            var names = new Collection<string>("Peter", "Maria");
            names.InsertAt(2, "Steve");
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria, Steve]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collections_InsertAtMiddle()
        {
            var names = new Collection<string>("Peter", "Maria");
            names.InsertAt(1, "Steve");
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Steve, Maria]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collections_InsertAtWithGrow()
        {
            var names = new Collection<string>("Peter", "Maria");
            int oldCapacity = names.Capacity;
            names.InsertAt(0, "Steve");
            names.InsertAt(3, "Mia");
            names.InsertAt(4, "Teodora");
            for (int i = names.Count; i >= 0; i--)
                names.InsertAt(i, "Item" + i);
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(names.ToString(), Is.EqualTo(
                "[Item0, Steve, Item1, Peter, Item2, Maria, Item3, Mia, Item4, Teodora, Item5]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collections_InsertAtInvalidIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            Assert.That(() => names.InsertAt(-1, "Jane"), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.InsertAt(3, "Steve"), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.InsertAt(500, "Nia"), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria]"));
        }

        [Test]
        public void Test_Collections_ExchangeMiddle()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            names.Exchange(1, 2);
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Steve, Maria, Mia]"));
        }

        [Test]
        public void Test_Collections_ExchangeFirstLast()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            names.Exchange(0, 3);
            Assert.That(names.ToString(), Is.EqualTo("[Mia, Maria, Steve, Peter]"));
        }

        [Test]
        public void Test_Collections_ExchangeInvalidIndexes()
        {
            var names = new Collection<string>("Peter", "Maria");
            Assert.That(() => names.Exchange(-1, 1), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.Exchange(1, -1), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.Exchange(2, 1), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.Exchange(1, 2), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.Exchange(-500, 500), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria]"));
        }

        [Test]
        public void Test_Collections_RemoveAtStart()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            var removed = names.RemoveAt(0);
            Assert.That(removed, Is.EqualTo("Peter"));
            Assert.That(names.ToString(), Is.EqualTo("[Maria, Steve, Mia]"));
        }

        [Test]
        public void Test_Collections_RemoveAtEnd()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            var removed = names.RemoveAt(3);
            Assert.That(removed, Is.EqualTo("Mia"));
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria, Steve]"));
        }

        [Test]
        public void Test_Collections_RemoveAtMiddle()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            var removed = names.RemoveAt(1);
            Assert.That(removed, Is.EqualTo("Maria"));
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Steve, Mia]"));
        }

        [Test]
        public void Test_Collections_RemoveAtInvalidIndex()
        {
            var names = new Collection<string>("Peter", "Maria");
            Assert.That(() => names.RemoveAt(-1), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.RemoveAt(2), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => names.RemoveAt(500), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Peter, Maria]"));
        }

        [Test]
        public void Test_Collections_RemoveAll()
        {
            var nums = new Collection<int>();
            const int itemsCount = 1000;
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            for (int i = 1; i <= itemsCount; i++)
            {
                var removed = nums.RemoveAt(0);
                Assert.That(removed, Is.EqualTo(i));
            }
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
            Assert.That(nums.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Collections_Clear()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            names.Clear();
            Assert.That(names.Count, Is.EqualTo(0));
            Assert.That(names.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collections_CountAndCapacity()
        {
            var nums = new Collection<int>();
            const int itemsCount = 1000;
            for (int i = 1; i <= itemsCount; i++)
            {
                nums.Add(i);
                Assert.That(nums.Count, Is.EqualTo(i));
                Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            }
            for (int i = itemsCount; i >= 1; i--)
            {
                nums.RemoveAt(i - 1);
                Assert.That(nums.Count, Is.EqualTo(i-1));
                Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            }
        }

        [Test]
        public void Test_Collections_ToStringEmpty()
        {
            var names = new Collection<string>();
            Assert.That(names.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collections_ToStringSingle()
        {
            var names = new Collection<string>("Nakov");
            Assert.That(names.ToString(), Is.EqualTo("[Nakov]"));
        }

        [Test]
        public void Test_Collections_ToStringMultiple()
        {
            var objects = new Collection<object>("Steve", "Maria", 20);
            Assert.That(objects.ToString(), Is.EqualTo("[Steve, Maria, 20]"));
        }

        [Test]
        public void Test_Collections_ToStringCollectionOfCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            Assert.That(nested.ToString(), Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collections_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count, Is.EqualTo(itemsCount));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }
    }
}
