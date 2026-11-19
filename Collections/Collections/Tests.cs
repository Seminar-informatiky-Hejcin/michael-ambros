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

    private bool LLIntAdd() {
        var ll = new LinkedList<int>();
        ll.Add(0);
        ll.Add(1);
        ll.Add(2);
        ll.Add(3);

        if (ll.Get(0) !=0) return false;
        if (ll.Get(1) !=1) return false;
        if (ll.Get(2) !=2) return false;
        if (ll.Get(3) !=3) return false;

        return true;
    }

    private bool LLIntRemove() {
        var ll = new LinkedList<int>();
        ll.Add(0);
        ll.Add(1);
        ll.Add(2);
        ll.Add(3);

        ll.Remove(0);
        ll.Remove(0);
        ll.Remove(0);

        if (ll.Get(0) !=3) return false;

        return true;
    }
    private bool LLIntModify() {
        var ll = new LinkedList<int>();
        ll.Add(0);
        ll.Add(1);
        ll.Add(2);
        ll.Add(3);

        ll.Modify(1,0);
        ll.Modify(2,0);
        ll.Modify(3,0);

        if (ll.Get(0) !=0) return false;
        if (ll.Get(1) !=0) return false;
        if (ll.Get(2) !=0) return false;
        if (ll.Get(3) !=0) return false;

        return true;
    }


    public void TestLinkedList()
    {
        if (this.LLIntAdd() != true) 
            throw new Exception("LLIntAdd test failed");
        if (this.LLIntRemove() != true) 
            throw new Exception("llintadd test failed");
        if (this.LLIntModify() != true) 
            throw new Exception("llintadd test failed");
    }

    private bool StackIntAdd(){
        var stack = new Stack<int>();

        stack.Push(1);
        if (stack.GetTop() != 1) 
            return false;
        stack.Push(2);
        if (stack.GetTop() != 2) 
            return false;
         stack.Push(3);
        if (stack.GetTop() != 3) 
            return false;

        return true;
    }

    private bool StackPop() {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        if (stack.Pop() != 4) return false;
        if (stack.Pop() != 3) return false;
        if (stack.Pop() != 2) return false;
        if (stack.Pop() != 1) return false;

        return true;
    }

    private bool StackCount() {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        if (stack.Count() != 4) return false;

        return true;
    }


    public void TestStack(){
        if (this.StackIntAdd() != true)
            throw new Exception("StackIntAdd test failed");
        if (this.StackPop() != true)
            throw new Exception("StackPop test failed");
        if (this.StackCount() != true)
            throw new Exception("StackCount test failed");
   }

    public bool QEnqueueDequeue() {
        var q = new Queue<int>(100);

        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);

        if (q.Dequeue() != 1) return false;
        if (q.Dequeue() != 2) return false;
        if (q.Dequeue() != 3) return false;
        if (q.Dequeue() != 4) return false;

        return true;
    }

    public bool QFull() {
        var q = new Queue<int>(4);

        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        try {
        q.Enqueue(4);
        }
        catch (Exception ex) {
            return true;
        }

        return false;
    }

    public bool QEmpty() {
        var q = new Queue<int>(4);

        q.Enqueue(1);
        q.Dequeue();
        try {
        q.Dequeue();
        }
        catch (Exception ex) {
            return true;
        }
        return false;
    }

    public bool QPeak() {
        var q = new Queue<int>(100);
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);

        if (q.Peak() != 1) return false;
        q.Dequeue();
        if (q.Peak() != 2) return false;
        q.Dequeue();
        if (q.Peak() != 3) return false;
        
        return true;
    }

    public bool QCapacity(){
        var q = new Queue<int>(4);
        q.Enqueue(1);
        if (q.Capacity() != 1) return false;
        q.Enqueue(1);
        if (q.Capacity() != 2) return false;
        q.Enqueue(1);
        if (q.Capacity() != 3) return false;
        q.Dequeue();
        if (q.Capacity() != 2) return false;
        q.Enqueue(1);
        if (q.Capacity() != 3) return false;
        q.Dequeue();
        if (q.Capacity() != 2) return false;

        return true;
  }



   public void TestQueue() {
        if (this.QEnqueueDequeue() != true)
            throw new Exception("QEnqueueDequeue test failed");
        if (this.QFull() != true)
            throw new Exception("QFull test failed");
         if (this.QEmpty() != true)
            throw new Exception("QEmpty test failed");
         if (this.QPeak() != true)
            throw new Exception("QPeak test failed");
         if (this.QCapacity() != true)
            throw new Exception("QCapacity test failed");
      }
}
