namespace Collections;



class Node<T>
{
    public T Value { get; set; }

    public Node<T> Next { get; set; }


    public Node(T value)
    {
        Value = value;
    }
}

class LinkedList<T>
{
    private Node<T> first;
    private Node<T> last;
    private int count;

    public int CountGet()
    {
        return count;
    }

    public void Add(T value)
    {
        count++;
        var node = new Node<T>(value);

        if (first == null) // empty
        {
            first = node;
        }
        else
        {
            last.Next = node;
        }

        last = node;
    }

    public void Remove(int index)
    {
        var node = Search(index);

        if (node == first)
        {
            first = node.Next;
            count--;
        }
        else
        {
            var nodeBefore = Search(index - 1);
            nodeBefore.Next = node.Next;

            if (node == last)
            {
                last = nodeBefore;
            }
            count--;
        }
    }

    private Node<T> Search(int index)
    {
        if (index < 0)
        {
            throw new IndexOutOfRangeException("Index is less than zero!");
        }

        var currentNode = first;

        for (int i = 0; i < index; i++)
        {
            if (currentNode == null)
            {
                throw new IndexOutOfRangeException("Index is bigger than list length!");
            }

            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    public T Get(int index)
    {
        return Search(index).Value;
    }

    public void Modify(int index, T value)
    {
        Search(index).Value = value;
    }
}