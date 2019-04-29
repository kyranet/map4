using System;

namespace Game
{
    public class ConnectedList
    {
        private class Node
        {
            public readonly int Data;
            public Node NextNode;

            public Node(int value, Node next)
            {
                Data = value;
                NextNode = next;
            }
        }

        private Node first { get; set; }
        private Node last { get; set; }
        public int Count { get; private set; }

        public ConnectedList()
        {
            first = last = null;
            Count = 0;
        }

        public int At(int position)
        {
            if (position < 0 || position >= Count) throw new Exception($"The element {position} does not exist.");

            var aux = first;
            while (position > 0)
            {
                aux = aux.NextNode;
                --position;
            }

            return aux.Data;
        }

        public void PushFront(int value)
        {
            first = new Node(value, first);
        }

        public void PushLast(int value)
        {
            if (first == null)
            {
                // If empty, set it as the first and last Node.
                first = last = new Node(value, null);
            }
            else
            {
                // Otherwise assign a new Node at the end and assign last to it.
                last = last.NextNode = new Node(value, null);
            }

            ++Count;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > Count) return false;

            if (index == 0)
            {
                first = first.NextNode;
            }
            else
            {
                Node aux = first, previous;
                do
                {
                    previous = aux;
                    aux = aux.NextNode;
                    --index;
                } while (index > 0);

                previous.NextNode = aux.NextNode;
            }

            --Count;
            return true;
        }

        public bool RemoveValue(int value)
        {
            // Empty list
            if (first == null) return false;

            // Find the element
            var found = false;
            var aux = first;
            var index = 0;
            do
            {
                if (aux.Data == value)
                {
                    found = true;
                }
                else
                {
                    ++index;
                }
            } while (!found && (aux = aux.NextNode) != null);

            // Remove element by its index
            return found && RemoveAt(index);
        }
    }
}