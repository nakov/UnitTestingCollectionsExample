# Unit Testing Example: Collection<T>, CircularQueue<T>

Unit testing examples with **C#** and **NUnit**.

## Class for Testing: Collection\<T>

We are given a **C# class [`Collection<T>`](https://github.com/nakov/UnitTestingExample/blob/main/Collections/Collection.cs)**, implementing a generic collection, holding an indexed sequence of elements:

```cs
public class Collection<T>
{
  public int Capacity { … }
  public int Count { … }
  public Collection(params T[] items) { … }
  public void Add(T item) { … }
  public void AddRange(params T[] items) { … }
  public T this[int index] { … }
  public void InsertAt(int index, T item) { … }
  public void Exchange(int index1, int index2) { … }
  public T RemoveAt(int index) { … }
  public void Clear() { … }
  public override string ToString() { … }
}
```

## Unit Tests for the Collection\<T> Class

Write **unit tests** to test the functionality of the [`Collection<T>`](https://github.com/nakov/UnitTestingExample/blob/main/Collections/Collection.cs) class, with high code coverage.

_Hint_: You may implement the following tests:

```cs
public class CollectionTests
{
  public void Test_Collection_EmptyConstructor() { … }
  public void Test_Collection_ConstructorSingleItem() { … }
  public void Test_Collection_ConstructorMultipleItems() { … }
  public void Test_Collection_Add() { … }
  public void Test_Collection_AddWithGrow() { … }
  public void Test_Collection_AddRange() { … }
  public void Test_Collection_GetByIndex() { … }
  public void Test_Collection_GetByInvalidIndex() { … }
  public void Test_Collection_SetByIndex() { … }
  public void Test_Collection_SetByInvalidIndex() { … }
  public void Test_Collection_AddRangeWithGrow() { … }
  public void Test_Collection_InsertAtStart() { … }
  public void Test_Collection_InsertAtEnd() { … }
  public void Test_Collection_InsertAtMiddle() { … }
  public void Test_Collection_InsertAtWithGrow() { … }
  public void Test_Collection_InsertAtInvalidIndex() { … }
  public void Test_Collection_ExchangeMiddle() { … }
  public void Test_Collection_ExchangeFirstLast() { … }
  public void Test_Collection_ExchangeInvalidIndexes() { … }
  public void Test_Collection_RemoveAtStart() { … }
  public void Test_Collection_RemoveAtEnd() { … }
  public void Test_Collection_RemoveAtMiddle() { … }
  public void Test_Collection_RemoveAtInvalidIndex() { … }
  public void Test_Collection_RemoveAll() { … }
  public void Test_Collection_Clear() { … }
  public void Test_Collection_CountAndCapacity() { … }
  public void Test_Collection_ToStringEmpty() { … }
  public void Test_Collection_ToStringSingle() { … }
  public void Test_Collection_ToStringMultiple() { … }
  public void Test_Collection_ToStringCollectionOfCollections() { … }
  public void Test_Collection_1MillionItems() { … }
}
```

## Expected Results

Sample output from the **unit tests**:

![image](https://user-images.githubusercontent.com/1689586/114179602-e0500380-9947-11eb-8cb2-737823fe5f62.png)

Sample output from the **code coverage**:

![image](https://user-images.githubusercontent.com/1689586/114179830-2a38e980-9948-11eb-8e4d-a21069de0088.png)


## Class for Testing: CircularQueue\<T>

We are given a **C# class [`CircularQueue<T>`](https://github.com/nakov/UnitTestingExample/blob/main/Collections/CircularQueue.cs)**, implementing the "**queue**" data structure, using a **circular buffer**:

```cs
public class CircularQueue<T>
{
    public CircularQueue(int capacity) { … }
    public int Count { … }
    public void Enqueue(T element) { … }
    public T Dequeue() { … }
    public T Peek() { … }
    public T[] ToArray() { … }
    public override string ToString() { … }
}
```

## Unit Tests for the CircularQueue\<T> Class

Write **unit tests** to test the functionality of the [`CircularQueue<T>`](https://github.com/nakov/UnitTestingExample/blob/main/Collections/CircularQueue.cs) class, with high code coverage.

_Hint_: You may implement the following tests:

```cs
class CircularQueueTests
{
    public void Test_CircularQueue_ConstructorDefault() { … }
    public void Test_CircularQueue_ConstructorWithCapacity() { … }
    public void Test_CircularQueue_Enqueue() { … }
    public void Test_CircularQueue_EnqueueWithGrow() { … }
    public void Test_CircularQueue_Dequeue() { … }
    public void Test_CircularQueue_DequeueEmpty() { … }
    public void Test_CircularQueue_EnqueueDequeue_WithRangeCross() { … }
    public void Test_CircularQueue_Peek() { … }
    public void Test_CircularQueue_PeekEmpty() { … }
    public void Test_CircularQueue_ToArray() { … }
    public void Test_CircularQueue_ToArray_WithRangeCross() { … }
    public void Test_CircularQueue_ToString() { … }
    public void Test_CircularQueue_MultipleOperations() { … }
    public void Test_CircularQueue_1MillionItems() { … }
}
```

## Expected Results

Sample output from the **unit tests**:

![image](https://user-images.githubusercontent.com/1689586/115532136-30ab5780-a29e-11eb-88ab-338cdcfd9a22.png)

