using System.Collections;
using System.Text;

namespace LinkedListTemplate;

public class MyLinkedList : IMyList, IEnumerable<string>
{
    private Node? _head;

    public void Insert(string element)
    {
        Node newNode = new(element);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // insert at last position
            current.Next = newNode;
        }
    }

    public int GetIndex(string element)
    {
        var index = 0;
        foreach (var e in this)
        {
            index++;
            if (e.Equals(element))
            {
                return index;
            }
        }

        return -1;
    }

    public bool Delete(string element)
    {
        // empty list
        if (_head == null)
        {
            return false;
        }

        var current = _head;
        // delete head
        if (_head.Value.Equals(element))
        {
            _head = current.Next;
            current = null;
            return true;
        }

        Node? previous = null;
        while (current.Next != null)
        {
            if (current.Value.Equals(element))
            {
                // delete node
                previous.Next = current.Next;
                current.Next = null;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    public bool Contains(string element)
    {
        foreach (var e in this)
        {
            if (e.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public IEnumerator<string> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        foreach (var e in this)
        {
            stringBuilder.Append("| ");
            stringBuilder.Append(e);
            stringBuilder.Append(" |");
            stringBuilder.Append(" -> ");
        }

        stringBuilder.Append("null");
        
        return stringBuilder.ToString();
    }

    private sealed class Node
    {
        public string Value { get; }

        public Node? Next { get; set; }

        public Node(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}