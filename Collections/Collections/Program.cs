namespace Collections;

class Program
{
    static void Main(string[] args)
    {
        Tests test = new Tests();
        test.TestDynamicArray();
        test.TestLinkedList();
        test.TestStack();
        test.TestQueue();
    }
}

