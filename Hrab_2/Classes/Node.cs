namespace Hrab_2.Classes
{
    /// <summary>
    /// Represents a <see cref="BinaryTree{T}"/> node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T data;
        public Node<T> LeftNode;
        public Node<T> RightNode;

        public Node(T value)
        {
            data = value;
        }
    }
}
