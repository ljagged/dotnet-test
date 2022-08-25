namespace Stack;
public interface IStack<T>
{
    void Push(T _elt);
    T Pop();

    T Peek();
    bool IsEmpty { get; }
}