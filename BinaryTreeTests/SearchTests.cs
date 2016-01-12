using System.Linq;
using BinaryTree;
using NUnit.Framework;

namespace BinaryTreeTests
{
    [TestFixture]
    public class SearchTests
    {

        BinaryTree<int> tree;

        [SetUp]
        public void BeforEachTest()
        {
            System.Diagnostics.Debug.WriteLine("Before {0}", TestContext.CurrentContext.Test.Name);
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
        public void Creation_Of_Single()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            foreach (int item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }

            Assert.IsFalse(tree.Contains(10), "Tree should not contain 10 yet");

            tree.Head = new BinaryTreeNode<int>(10);

            Assert.IsTrue(tree.Contains(10), "Tree should contain 10");

            int count = 0;
            foreach (int item in tree)
            {
                count++;
                Assert.AreEqual(1, count, "There should be exactly one item");
                Assert.AreEqual(item, 10, "The item value should be 10");
            }
        }


        [Test]
        public void Creation_Of_BinaryTree()
        {

            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  


            int count = 0;
            foreach (int item in tree)
            {
                count++;

            }

            Assert.AreEqual(9, count, "There should be exactly 9 items in the tree");
            System.Diagnostics.Debug.WriteLine(count);

        }


        [Test]
        public void FindMaxNumberofNodes()
        {

            //         2                         
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  


            Assert.AreEqual(4, tree.FindHeight(tree.Head), "There should be exactly 9 items in the tree");
            System.Diagnostics.Debug.WriteLine(tree.FindHeight(tree.Head));

        }


        [Test]
        public void Enumerator_Of_Single()
        {
            //         2
            //       /   \
            //      
            tree = new BinaryTree<int>();

            foreach (int item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }

            Assert.IsFalse(tree.Contains(2), "Tree should not contain 2 yet");

            tree.Head = new BinaryTreeNode<int>(2);

            Assert.IsTrue(tree.Contains(2), "Tree should contain 10");

            int count = 0;
            foreach (int item in tree)
            {
                count++;
                Assert.AreEqual(1, count, "There should be exactly one item");
                Assert.AreEqual(item, 2, "The item value should be 2");
            }
        }


        [Test]
        public void InOrder_Enumerator_Char()
        {


            //         a
            //       /   \
            //      c     d
            //     / \    
            //    g   b
            //      



            BinaryTree<char> tree2 = new BinaryTree<char>();

            tree2.Head = new BinaryTreeNode<char>('a');
            tree2.Head.Left = new BinaryTreeNode<char>('c');
            tree2.Head.Left.Left = new BinaryTreeNode<char>('g');
            tree2.Head.Left.Right = new BinaryTreeNode<char>('b');

            tree2.Head.Right = new BinaryTreeNode<char>('d');

            char[] expected = new[] { 'g', 'c', 'b', 'a', 'd' };

            int index = 0;

            foreach (int actual in tree2)
            {
                Assert.AreEqual(expected[index++], actual, "The item enumerated in the wrong order");
                System.Diagnostics.Debug.WriteLine(actual);
            }
        }

        [Test]
        public void InOrder_Enumerator_String()
        {


            //         "a"
            //       /   \
            //      "c"    " d"
            //     / \    
            //    "g"   "b"
            //      



            BinaryTree<string> tree3 = new BinaryTree<string>();

            tree3.Head = new BinaryTreeNode<string>("a");
            tree3.Head.Left = new BinaryTreeNode<string>("c");
            tree3.Head.Left.Left = new BinaryTreeNode<string>("g");
            tree3.Head.Left.Right = new BinaryTreeNode<string>("b");

            tree3.Head.Right = new BinaryTreeNode<string>("d");

            string[] expected = new[] { "g", "c", "b", "a", "d" };

            int index = 0;

            foreach (string actual in tree3)
            {
                Assert.AreEqual(expected[index++], actual, "The item enumerated in the wrong order");
                System.Diagnostics.Debug.WriteLine(actual);
            }
        }

        [Test]
        public void InOrder_Enumerator_SearchNode()
        {


            //         2
            //       /   \
            //      7     5
            //     / \     \
            //    2   6     9
            //       / \   / 
            //      5  11  4  

            int serchId = 11;

            var resultSet = tree.InOrderTraversalSerchById(serchId);
            Assert.AreEqual(0, resultSet.Count(), "Result size should be 0");
            System.Diagnostics.Debug.WriteLine(resultSet.Count());


            serchId = 105;

            resultSet = tree.InOrderTraversalSerchById(serchId);
            Assert.AreEqual(1, resultSet.Count(), "Result size should return only one result");
            System.Diagnostics.Debug.WriteLine(resultSet.Count());

            Assert.AreEqual(105, resultSet.First().Id, " Id of the return Result should be 105 ");
            System.Diagnostics.Debug.WriteLine(resultSet.First());



        }

    }
}
