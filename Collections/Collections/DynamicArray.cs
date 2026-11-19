using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Collections;

public class DynamicArray<T>
{

    private T[] internalArray;

    public int Count { get; private set; }
    public int Capacity { get; private set; }
    private int multiplicatorForResizingArray = 2;

    public DynamicArray()
    {
        Capacity = 4;
        internalArray = new T[Capacity];
        Count = 0;
    }

    public T GetValue(int index)
    {
        if (index > Count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        return internalArray[index];
    }

    public void AddValue(T value)
    {
        //todo: max kapacity
        if (Count == Capacity)
        {
            Capacity = Capacity * multiplicatorForResizingArray;
            var newInternalArray = new T[Capacity];

            for (int i = 0; i < Count; i++)
            {
                newInternalArray[i] = internalArray[i];
            }

            internalArray = newInternalArray;
        }

        //vleze se do kapacity
        internalArray[Count] = value;
        Count++;
    }

    public void Pop()
    {
        Count--;
        if (Capacity / 2 > Count)
        {
            Capacity =  Capacity / 2;
        }
    }




}
