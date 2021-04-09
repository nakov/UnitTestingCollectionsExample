# Unit Testing - Example

Unit testing example with **C#** and **NUnit**.

## Class for Testing

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

## Unit Tests for the Collection<T> Class

Write unit tests to test the functionality of the [`Collection<T>`](https://github.com/nakov/UnitTestingExample/blob/main/Collections/Collection.cs) class, with high code coverage.

_Hint_: You may implement the following tests:

```cs
public class CollectionsTests
{
  public void Test_Collections_EmptyConstructor() { … }
  public void Test_Collections_ConstructorSingleItem() { … }
  public void Test_Collections_ConstructorMultipleItems() { … }
  public void Test_Collections_Add() { … }
  public void Test_Collections_AddWithGrow() { … }
  public void Test_Collections_AddRange() { … }
  public void Test_Collections_GetByIndex() { … }
  public void Test_Collections_GetByInvalidIndex() { … }
  public void Test_Collections_SetByIndex() { … }
  public void Test_Collections_SetByInvalidIndex() { … }
  public void Test_Collections_AddRangeWithGrow() { … }
  public void Test_Collections_InsertAtStart() { … }
  public void Test_Collections_InsertAtEnd() { … }
  public void Test_Collections_InsertAtMiddle() { … }
  public void Test_Collections_InsertAtWithGrow() { … }
  public void Test_Collections_InsertAtInvalidIndex() { … }
  public void Test_Collections_ExchangeMiddle() { … }
  public void Test_Collections_ExchangeFirstLast() { … }
  public void Test_Collections_ExchangeInvalidIndexes() { … }
  public void Test_Collections_RemoveAtStart() { … }
  public void Test_Collections_RemoveAtEnd() { … }
  public void Test_Collections_RemoveAtMiddle() { … }
  public void Test_Collections_RemoveAtInvalidIndex() { … }
  public void Test_Collections_RemoveAll() { … }
  public void Test_Collections_Clear() { … }
  public void Test_Collections_CountAndCapacity() { … }
  public void Test_Collections_ToStringEmpty() { … }
  public void Test_Collections_ToStringSingle() { … }
  public void Test_Collections_ToStringMultiple() { … }
  public void Test_Collections_ToStringCollectionOfCollections() { … }
  public void Test_Collections_1MillionItems() { … }
}
```

## Expected Results

Sample output from the **unit tests**:

![image](https://user-images.githubusercontent.com/1689586/114179602-e0500380-9947-11eb-8cb2-737823fe5f62.png)

Sample output from the **code coverage**:

![image](https://user-images.githubusercontent.com/1689586/114179830-2a38e980-9948-11eb-8e4d-a21069de0088.png)
