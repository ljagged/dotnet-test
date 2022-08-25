namespace Stack;
using System;

public class LinkedStack<T> : IStack<T>
{
    Entry? _top;

    public void Push(T data)
    {
        _top = new Entry(_top, data);
    }

    public T Pop()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");
        T result = _top.Data;
        _top = _top.Next;

        return result;
    }

    public T Peek()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");
        return _top.Data;
    }

    public bool IsEmpty => _top == null;

    class Entry
    {
        public Entry? Next { get; set; }
        public T Data { get; set; }

        public Entry(Entry? next, T data)
        {
            Next = next;
            Data = data;
        }
    }
}

