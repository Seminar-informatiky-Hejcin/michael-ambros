using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Caesar;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("write me the input string");
        // var msg = Console.ReadLine();    
        var msg = "abcdefghijklmnopqrstuvwxyz";
        Console.WriteLine(msg);

        Console.WriteLine("write me the offset you want to use");
        int offset = int.Parse(Console.ReadLine());

        var cypher = Cypher(msg, offset);

        Console.WriteLine(cypher);
        Console.WriteLine(msg);
    }

    static string Cypher(string msg, int offset)
    {
        string output = "";
        foreach (char chr in msg)
        {
           if (chr == 32)
            {
                output = output + " ";
                continue;
            }
            // if ((chr<64 || chr>91) && (chr < 96 || chr > 123))
            if (chr >= 'a' && chr <= 'z')
            {
                output = output + (char) ((chr-'a' + offset) % 26 + 'a');
            }
            if (chr >= 'A' && chr <= 'Z')
            {
                output = output + (char) ((chr-'A' + offset) % 26 + 'A');
            }
         }
        
        return output;
    }

}
