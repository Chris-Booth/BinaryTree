using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace BinaryTree
{
    [PublicAPI]
    internal class Program
    {
        private static void Main()
        {
            var binaryTree = new BinarySearchTree<long>();

            binaryTree.InsertNode(0);

            binaryTree.InsertNode(10);

            binaryTree.InsertNode(-10);

            var node = binaryTree.FindByValue(10);

            Console.WriteLine($"Found Node 10 with value {node?.ToString() ?? "NULL"}");

            binaryTree.RemoveNode(10);

            node = binaryTree.FindByValue(10);

            Console.WriteLine($"Removed Node 10. Found {node?.ToString() ?? "NULL"} for value 10.");

            node = binaryTree.FindByValue(-10);

            Console.WriteLine($"Found Node -10 with value {node?.ToString() ?? "NULL"}");

            binaryTree = new BinarySearchTree<long>(0L, 9, 55, 4, 22, 16, -1, -5);

            node = binaryTree.FindByValue(-5);

            Console.WriteLine($"Found Node -5 with value {node?.ToString() ?? "NULL"}");

            binaryTree.InsertNode(-20);

            node = binaryTree.FindByValue(-20);

            Console.WriteLine($"Found Node -20 with value {node?.ToString() ?? "NULL"}");

            var depth = binaryTree.GetLevel();

            Console.WriteLine($"There are {depth} levels in the tree");

            var items = new Queue<long>();

            binaryTree.GetOnLevel(items, depth);

            Console.WriteLine($"There are {string.Join(", ", items)} items in the tree at level {depth}");

            items = new Queue<long>();

            binaryTree.GetOnLevel(items, 2);

            Console.WriteLine($"There are {string.Join(", ", items)} items in the tree at level {2}");

            var treeItems = new List<long>();

            binaryTree.GetNodes(treeItems);

            Console.WriteLine($"There are {string.Join(", ", treeItems.OrderBy(item => item))} items in the tree");

            Console.ReadLine();
        }
    }
}
