namespace Collections;

// i've decided to make the queue with fixed length, but with *always* O(1)
class Queue<T> {
    private T[] ia;
    private int head = 0;
    private int tail = 0;
    private int capacity;
    
    public Queue(int capacity) {
        ia = new T[capacity];
        this.capacity = capacity;
    }

    public void Enqueue(T value) {
        // head and tail of queue will colide
        if ((head + 1) % this.capacity == tail) {
            throw new Exception("Queue is full");
        }
        //add value
        ia[head] = value;

        // move head
        head = (head + 1) % this.capacity;
    }

    public T Dequeue() {
        var retVal = ia[tail];

        // head and tail of queue will colide
        if (tail == head) {
            throw new Exception("Queue is empty");
        }
        // move head
        tail = (tail + 1) % this.capacity;
 
        return retVal;
    }

    public T Peak(){
        return ia[tail];
    }

    public int Capacity() {
        return ((head + capacity) - tail) % capacity;
    }


}