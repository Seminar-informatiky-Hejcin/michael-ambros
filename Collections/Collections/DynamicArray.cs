using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Collections;

public class DynamicArray
{

    private string[] internalArray;

    public int Count {get; private set;}
    public int Capacity {get; private set;}
    private int multiplicatorForResizingArray = 2;

    public DynamicArray()
    {
        Capacity = 4;
        internalArray = new string[Capacity];
        Count = 0;
    }

    public string GetValue(int index)
    {
        if (index > Count || 0 <= index)
        {
            throw new IndexOutOfRangeException();
        }

        return internalArray[index];
    }

    public void AddValue(string value)
    {
        //todo: max kapacity
        if (Count == Capacity)
        {
            Capacity = Capacity * multiplicatorForResizingArray;
            var newInternalArray = new string[Capacity];

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




}
