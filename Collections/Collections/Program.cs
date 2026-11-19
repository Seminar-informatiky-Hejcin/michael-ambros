namespace Collections;

class Program
{
    static void Main(string[] args)
    {
        // var list = new LinkedList<string>();
        // Console.WriteLine(list.CountGet());

        // list.Add("ahoj");
        // Console.WriteLine(list.CountGet());

        // list.Add("pepo");
        // Console.WriteLine(list.CountGet());

        // list.Remove(1);
        // Console.WriteLine(list.CountGet());


        // Console.WriteLine(list.Get(0));

        var dynArr = new DynamicArray();

        dynArr.AddValue("lorem");
        dynArr.AddValue("ipsum");
        dynArr.AddValue("dolor");
        dynArr.AddValue("sit");
        dynArr.AddValue("amet");

        Console.WriteLine(dynArr.Count);
        Console.WriteLine(dynArr.Capacity);
    }
}

