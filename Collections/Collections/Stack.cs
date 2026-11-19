namespace Collections;

class Stack<T> {
    private DynamicArray<T> internal_arr = new DynamicArray<T>();

    public void Push(T value){
        internal_arr.AddValue(value);
    }

    public T GetTop() {
        return internal_arr.GetValue(internal_arr.Count-1);
    }

    public T Pop() {
        T returnValue =  internal_arr.GetValue(internal_arr.Count-1);

        internal_arr.Pop();

        return returnValue;
    }

    public int Count() {
        return internal_arr.Count;
    }
}