using System;
using Hrab_2.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hrab_2.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void Add_WhenArgumentIsNull_ShouldThrowArgumentNullExeption()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>("PreOrder");

            Student student = null;
            try
            {
                Tree.Add(student);
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "null");
                return;
            }

            Assert.Fail("");
        }

        [TestMethod]
        public void Add_WhenRootIsNull_ShouldAddRootInBinaryTree()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>("PreOrder");

            Student student = new Student(5, "Mark", "Pupkin");

            Tree.Add(student);

            Node<Student> root = new Node<Student>(student);

            foreach (var value in Tree)
                Assert.AreEqual(root.data, value, "Root is not created correctly");
        }

        [TestMethod]
        public void Add_WhenNodeIsNotNull_ShouldCreateNewRightNodeCorrectly()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>("PostOrder");

            Student student1 = new Student(5, "Mark", "Pupkin");
            Student student2 = new Student(10, "Ivan", "Ivanov");

            Tree.Add(student1);
            Tree.Add(student2);

            Node<Student> RightNode = new Node<Student>(student2);

            foreach (var value in Tree)
            {
                Assert.AreEqual(RightNode.data, value, "Node is not created correctly.");
                return;
            }    
        }

        [TestMethod]
        public void Add_WhenNodeIsNotNull_ShouldCreateNewLeftNodeCorrectly()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>("InOrder");

            Student student1 = new Student(5, "Mark", "Pupkin");
            Student student2 = new Student(4, "Ivan", "Ivanov");

            Tree.Add(student1);
            Tree.Add(student2);

            Node<Student> LeftNode = new Node<Student>(student2);

            foreach (var value in Tree)
            {
                Assert.AreEqual(LeftNode.data, value, "Node is not created correctly.");
                return;
            }
        }
    }
}
