using System;
using System.Linq;
using BinaryTree;
using NUnit.Framework;

namespace BinaryTreeTests
{
    [TestFixture]
    public class EnumerationTests
    {
        BinaryTree<int> tree;

        [SetUp]
        public void BeforEachTest()
        {
            Console.WriteLine("Before {0}", TestContext.CurrentContext.Test.Name);
            tree = new BinaryTree<int>();

            tree.Head = new BinaryTreeNode<int>(101, 2);
            tree.Head.Left = new BinaryTreeNode<int>(102, 7);
            tree.Head.Left.Left = new BinaryTreeNode<int>(103, 2);
            tree.Head.Left.Right = new BinaryTreeNode<int>(104, 6);
            tree.Head.Left.Right.Left = new BinaryTreeNode<int>(105, 5);
            tree.Head.Left.Right.Right = new BinaryTreeNode<int>(106, 11);

            tree.Head.Right = new BinaryTreeNode<int>(107, 5);
            tree.Head.Right.Right = new BinaryTreeNode<int>(108, 9);
            tree.Head.Right.Right.Left = new BinaryTreeNode<int>(109, 4);


        }



        [Test]
        public void InOrder_Enumerator()
        {

            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  



            int[] expected = new[] { 2, 7, 5, 6, 11, 2, 5, 4, 9 };

            int index = 0;

            foreach (int actual in tree)
            {
                Assert.AreEqual(expected[index++], actual, "The item enumerated in the wrong order");
                System.Diagnostics.Debug.WriteLine(actual);
            }
        }


        [Test]
        public void InOrder_Delegate()
        {
            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  

            int[] expected = new[] { 2, 7, 5, 6, 11, 2, 5, 4, 9 };

            int index = 0;

            tree.InOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }


        [Test]
        public void PreOrder_Delegate()
        {


            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  


            int[] expected = new[] { 2, 7, 2, 6, 5, 11, 5, 9, 4 };

            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            //tree.PreOrderTraversal()
        }

        [Test]
        public void PostOrder_Delegate()
        {

            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4   


            int[] expected = new[] { 2, 5, 11, 6, 7, 4, 9, 5, 2 };

            int index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));

        }




    }
}
