using System;
using System.Collections;
using System.Collections.Generic;

namespace Hrab_2.Classes
{
    public delegate void BinaryTreeStateHandler(object sender, BinaryTreeEventArgs e);

    //public T value
    public class BinaryTreeEventArgs : EventArgs
    {
        public string message { get; private set; }

        public BinaryTreeEventArgs(string message)
                : base() => this.message = message;
    }

    /// <summary>
    /// Represents a store of any data in sorted form.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Works when new data has added to the <see cref="BinaryTree{T}"/>.
        /// </summary>
        public event BinaryTreeStateHandler Added = null;

        private Node<T> root;
        private string TraversalType; //Field for using the desired traversal

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class 
        /// with the follow traversal types:
        /// <para />PreOrder, InOrder, PostOrder, Across.
        /// </summary>
        /// <param name="bypassType"></param>
        public BinaryTree(string TraversalType)
        {
            root = null;

            //сделать enum
            //Implementing the traversal type selection
            if (TraversalType == "PreOrder" || TraversalType == "InOrder" ||
                TraversalType == "PostOrder" || TraversalType == "Across")
                this.TraversalType = TraversalType;
            else throw new ArgumentException("TraversalType");
        }

        private bool isRoot() => root == null;

        private bool isValueNull(T value) 
            => EqualityComparer<T>.Equals(value, null);

        private bool isLeftNodeNull(Node<T> node) 
            => node.LeftNode == null;

        private bool isRightNodeNull(Node<T> node) 
            => node.RightNode == null;

        private bool isNodeNull(Node<T> node) 
            => node == null;

        /// <summary>
        /// Add in <see cref="BinaryTree{T}"/> new data. 
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (isValueNull(value))
                throw new ArgumentNullException("null");

            if (isRoot())
                root = new Node<T>(value);
            else
                createNode(root, value);

            //передавать объект, а не сообщение (value)
            Added?.Invoke(this, new BinaryTreeEventArgs($"A new addition to the binary tree: {value}"));
        }

        /// <summary>
        /// Clears a <see cref="BinaryTree{T}"/>.
        /// </summary>
        public void Clear()
        {
            if (!isRoot())
                root = null;
        }

        //if root != null creates a new node
        private void createNode(Node<T> node, T value)
        {
            if (node.data.CompareTo(value) > 0)
            {
                if (isLeftNodeNull(node))
                    node.LeftNode = new Node<T>(value);
                else
                    createNode(node.LeftNode, value);
            }
            else if (node.data.CompareTo(value) < 0)
            {
                if (isRightNodeNull(node))
                    node.RightNode = new Node<T>(value);
                else
                    createNode(node.RightNode, value);
            }
        }

        //Traversal type - preorder (center node, left node, right node)
        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.data;

            if (!isLeftNodeNull(node))
            {
                foreach (var value in PreOrder(node.LeftNode))
                    yield return value;
            }
            if (!isRightNodeNull(node))
            {
                foreach (var value in PreOrder(node.RightNode))
                    yield return value;
            }
        }

        //Traversal type - inorder (left node, center node, right node)
        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (!isLeftNodeNull(node))
            {
                foreach (var value in InOrder(node.LeftNode))
                    yield return value;
            }

            yield return node.data;

            if (!isRightNodeNull(node))
            {
                foreach (var value in InOrder(node.RightNode))
                    yield return value;
            }
        }

        //Traversal type - postorder (right node, center node, left node)
        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (!isRightNodeNull(node))
            {
                foreach (var value in PostOrder(node.RightNode))
                    yield return value;
            }

            yield return node.data;

            if (!isLeftNodeNull(node))
            {
                foreach (var value in PostOrder(node.LeftNode))
                    yield return value;
            }
        }

        //Traversal type - across (1 level of nodes, 2, ..., n)
        private IEnumerable<T> Across(Node<T> node)
        {
            var queue = new Queue<Node<T>>();

            if (isNodeNull(node))
                throw new ArgumentNullException("node");

            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                if (!isLeftNodeNull(queue.Peek()))
                    queue.Enqueue(queue.Peek().LeftNode);
                if (!isRightNodeNull(queue.Peek()))
                    queue.Enqueue(queue.Peek().RightNode);

                yield return queue.Peek().data;
                queue.Dequeue();
            }
        }

        //// Depending on the selected traversal type, do traversal
        public IEnumerator<T> GetEnumerator()
        {
            switch (TraversalType)
            {
                case "PreOrder":
                    foreach (var value in PreOrder(root))
                        yield return value;
                    break;
                case "InOrder":
                    foreach (var value in InOrder(root))
                        yield return value;
                    break;
                case "PostOrder":
                    foreach (var value in PostOrder(root))
                        yield return value;
                    break;
                case "Across":
                    foreach (var value in Across(root))
                        yield return value;
                    break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


