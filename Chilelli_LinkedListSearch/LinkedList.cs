using System.Text;

namespace Chilelli_LinkedListSearch
{
    class LinkedList
    {
        private Node head;
        private Node tail;

 public Node Add(MetaData data)
        {
            // check for empty list. If empty add to head
            if (head == null)
            {
                head = new Node(data);
                tail = head;
                return head;
            }

            Node current = head;

            // if not empty, search the list for insert point
            while (current != null)
            {
                Node next = current.Next;
                // handle null tail
                if (next == null)
                {
                    if (current.Data.Name.CompareTo(data.Name) > 0)
                    {
                        Node temp = new Node(data);
                        temp.Next = head;
                        head = temp;
                        return temp;
                    }
                    else
                    {
                        tail.Next = new Node(data);
                        tail.Next.Previous = tail;
                        tail = tail.Next;
                        return tail;
                    }
                }
                // handle new head
                if (current.Data.Name.CompareTo(data.Name) > 0)
                {
                    Node temp = new Node(data);
                    temp.Next = head;
                    head = temp;
                    return temp;
                }

                // insert in middle
                if (current.Data.Name.CompareTo(data.Name) < 0 && next.Data.Name.CompareTo(data.Name) >= 0)
                {
                    current.Next = new Node(data);
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return current.Next;
                }
                current = current.Next;
            }
            return null;

        }
         public string Print()
        {
            // Remove later for encapsulation
            Node current = head;
            StringBuilder sb = new StringBuilder();

            while (current != null)
            {
                sb.Append(current.Data.Name + "\n");
                current = current.Next;
            }
            return sb.ToString();
        }
        public Node SearchBoth(string data)
        {
            // search for node containing data from front and back
            Node start = head;
            Node end = tail;
            while (end != null)
            {
                if (end == null) { return null; }
                else if (start.Data.Name.ToLower() == data) { return start; }
                else if (end.Data.Name.ToLower() == data) { return end; }
                end = end.Previous;
                start = start.Next;
            }
            return null;
        }
        public Node theHead { get { return head; } }
        public Node[] topName()
        {
            Node current = head;
            Node next = head.Next;
            Node topMale = head;
            Node topIronman = head;
            Node[] popular = new Node[2];

            while (current.Data.Gender == 'M' || current.Data.Gender == 'F')
            {
                if (current.Data.Gender == 'M') { topMale = current; }
                else { topIronman = current; }
                current = current.Next;
                if (current.Next == null) { break; }
            }
            current = head;
            while (current != null)
            {
                if (current == null) { return null; }
                if (topMale.Data.Rank <= current.Data.Rank && current.Data.Gender == 'M') { topMale = current; }
                else if (topIronman.Data.Rank <= current.Data.Rank && current.Data.Gender == 'F') { topIronman = current; }
                current = current.Next;
                if (current.Next == null)
                {
                    popular[0] = topMale;
                    popular[1] = topIronman;
                    return popular;
                }
                next = current.Next;
            }
            return null;
        }
    }
}