using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace MachShip
{
    class Program
    {
        static void Main(string[] args)
        {

            string searchItem;
            List<string> foundNodes;
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Head = new BinaryTreeNode<int>(2);
            tree.Head.Left = new BinaryTreeNode<int>(7);
            tree.Head.Left.Left = new BinaryTreeNode<int>(2);
            tree.Head.Left.Right = new BinaryTreeNode<int>(6);
            tree.Head.Left.Right.Left = new BinaryTreeNode<int>(5);
            tree.Head.Left.Right.Right = new BinaryTreeNode<int>(11);

            tree.Head.Right = new BinaryTreeNode<int>(5);
            tree.Head.Right.Right = new BinaryTreeNode<int>(9);
            tree.Head.Right.Right.Left = new BinaryTreeNode<int>(4);


            //tree.RecursiveInorder(tree.Head);

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            tree.InOrderTraversal(delegate (int i) { Console.Write(i + " | "); });

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            //tree.InOrderTraversal(delegate (int i) { Console.Write(i + " | "); }); ;


            Console.Write("Please enter the node Id to search : ");
            //searchItem =  Console.ReadLine();


            while (true)
            {

                foundNodes = new List<string>();


                searchItem = Console.ReadLine();

                if (string.IsNullOrEmpty(searchItem))
                {
                    return;
                }


                foreach (int item in tree)
                {
                    if (item.CompareTo(Int32.Parse(searchItem)) == 0)
                        foundNodes.Add(item.ToString());
                }



                if (foundNodes.Count > 0)
                {
                    Console.WriteLine("{0} Item(s) found with matching nodes {1} ", foundNodes.Count, searchItem);

                }
                else
                {
                    Console.WriteLine("No Item(s) found matching nodes {0}", searchItem);
                }

            }

            Console.ReadLine();

        }
    }
}
