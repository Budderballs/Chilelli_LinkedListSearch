namespace Chilelli_LinkedListSearch
{
    class Node
    {
        public static int nodeCount;
        public Node Previous;
        public Node Next;
        public MetaData Data;
        public Node(MetaData data)
        {
            Next = null;
            Previous = null;
            Data = data;
            nodeCount++;
        }
    }
}
