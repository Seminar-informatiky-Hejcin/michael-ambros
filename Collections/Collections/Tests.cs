using System;
using System.Runtime.InteropServices.Swift;

namespace Collections;


public class Tests
{
    private bool DynArrIntAdd()
    {
        var dynArr = new DynamicArray<int>();

        dynArr.AddValue(1);
        dynArr.AddValue(2);
        dynArr.AddValue(3);

        if (dynArr.GetValue(0) != 1) return false;
        if (dynArr.GetValue(1) != 2) return false;
        if (dynArr.GetValue(2) != 3) return false;

        return true;

    }

    private bool DynArrIntRemove()
    {
        var dynArr = new DynamicArray<int>();

        for (int i = 0; i < 10; i++)
            dynArr.AddValue(10);
        for (int i = 0; i < 9; i++)
            dynArr.Pop();


        if (dynArr.Capacity != 2) return false;
        if (dynArr.Count != 1) return false;

        return true;

    }

    private bool DynArrCorrectScaling()
    {
        var dynArr = new DynamicArray<int>();

        for (int i = 0; i < 10; i++)
        {
            dynArr.AddValue(10);
        }

        if (dynArr.Capacity != 16) return false;
        if (dynArr.Count != 10) return false;

        return true;

    }

    private bool DynArrStringHandling()
    {
        var dynArr = new DynamicArray<string>();

        dynArr.AddValue("a");
        dynArr.AddValue("b");
        dynArr.AddValue("c");
        dynArr.AddValue("d");
        dynArr.AddValue("e");

        if (dynArr.Count != 5) return false;
        if (dynArr.Capacity != 8) return false;

        if (dynArr.GetValue(0) != "a") return false;
        if (dynArr.GetValue(3) != "d") return false;
        if (dynArr.GetValue(4) != "e") return false;

        dynArr.Pop();
        dynArr.Pop();
        dynArr.Pop();
        dynArr.Pop();

        if (dynArr.Count != 1) return false;
        if (dynArr.Capacity != 2) return false;

        if (dynArr.GetValue(0) != "a") return false;

        return true;

    }
    public void TestDynamicArray()
    {
        if (this.DynArrIntAdd() != true)
        {
            throw new Exception("int add test didn't passd");
        }

        if (this.DynArrCorrectScaling() != true)
        {
            throw new Exception("CorrectScaling test didn't passd");
        }


        if (this.DynArrIntRemove() != true)
        {
            throw new Exception("int remove test didn't passd");
        }

        if (this.DynArrStringHandling() != true)
        {
            throw new Exception("StringHandling test didn't passd");
        }

    }

    public void TestLinkedList()
    {
        var ll = new LinkedList<int>
    }
}
