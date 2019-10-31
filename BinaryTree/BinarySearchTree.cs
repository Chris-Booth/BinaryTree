using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree(params T[] values)
        {
            if (values.Length == 0) return;

            Root = BinaryTreeNode.CreateNode(values[0]);
            for (var i = 1; i < values.Length; i++)
            {
                InsertNode(values[i]);
            }
        }

        public BinaryTreeNode<T> Root { get; private set; }

        public bool InsertNode(T data)
        {
            var node = BinaryTreeNode.CreateNode(data);

            if (Root == null)
            {
                Root = node;
                return true;
            }

            var current = Root;

            while (current != null)
            {
                if (node > current || node < current)
                {
                    var left = node < current;
                    var nextNode = GetBranch(current, left);
                    if (nextNode != null)
                    {
                        current = nextNode;
                        continue;
                    }

                    SetBranch(current, node, left);
                }
                else
                {
                    break;
                }
            }

            return true;
        }

        private static void SetBranch(BinaryTreeNode<T> current, BinaryTreeNode<T> nodeData, bool left = true)
        {
            if (left)
                current.Left = nodeData;
            else
                current.Right = nodeData;
        }

        private static BinaryTreeNode<T> GetBranch(BinaryTreeNode<T> current, bool left = true)
        {
            return left ? current.Left : current.Right;
        }

        public int GetLevel(BinaryTreeNode<T> binaryTreeNode = default, int current = 1)
        {
            int rightLevel = default, leftLevel = default;
            binaryTreeNode ??= Root;

            if (binaryTreeNode.Right != null)
            {
                rightLevel = GetLevel(binaryTreeNode.Right, current + 1);
            }

            if (binaryTreeNode.Left != null)
            {
                leftLevel = GetLevel(binaryTreeNode.Left, current + 1);
            }

            if (rightLevel == 0 && leftLevel == 0) return current;

            return rightLevel > leftLevel ? rightLevel : leftLevel;
        }

        public void GetOnLevel(Queue<T> result, int trgLevel, BinaryTreeNode<T> binaryTreeNode = default, int curLevel = 1)
        {
            while (true)
            {
                binaryTreeNode ??= Root;
                if (curLevel == trgLevel)
                {
                    result.Enqueue(binaryTreeNode.Data);
                }
                else
                {
                    if (binaryTreeNode.Left != null)
                    {
                        GetOnLevel(result, trgLevel, binaryTreeNode.Left, curLevel + 1);
                    }

                    if (binaryTreeNode.Right != null)
                    {
                        binaryTreeNode = binaryTreeNode.Right;
                        curLevel += 1;
                        continue;
                    }
                }

                break;
            }
        }


        public void GetNodes(IList<T> result, BinaryTreeNode<T> binaryTreeNode = default, int curLevel = 1)
        {
            while (true)
            {
                binaryTreeNode ??= Root;
                result.Add(binaryTreeNode.Data);
                if (binaryTreeNode.Left != null)
                {
                    GetNodes(result, binaryTreeNode.Left, curLevel + 1);
                }

                if (binaryTreeNode.Right != null)
                {
                    binaryTreeNode = binaryTreeNode.Right;
                    curLevel += 1;
                    continue;
                }

                break;
            }
        }

        public BinaryTreeNode<T> FindByValue(T data)
        {
            var node = Root;

            for (; ; )
            {
                if (node == null) return null;

                if (data.Equals(node.Data))
                {
                    return node;
                }

                if (data.CompareTo(node.Data) > 0)
                {
                    node = node.Right;
                }
                else if (data.CompareTo(node.Data) < 0)
                {
                    node = node.Left;
                }

                else
                    return null;
            }
        }

        public bool RemoveNode(T data)
        {
            var current = Root;

            for (; ; )
            {
                if (current == null) return false;

                BinaryTreeNode<T> nextNode;
                if (data.CompareTo(current.Data) > 0)
                {
                    nextNode = current.Right;
                }
                else if (data.CompareTo(current.Data) < 0)
                {
                    nextNode = current.Left;
                }
                else
                {
                    return false;
                }

                if (data.Equals(nextNode.Data))
                {
                    if (nextNode.Left != null && nextNode.Right != null) return false;

                    if (nextNode.Left != null)
                    {
                        RemapNode(current, nextNode, nextNode.Left);
                        return true;
                    }

                    RemapNode(current, nextNode, nextNode.Right);
                    return true;
                }

                current = nextNode;
            }
        }

        private static void RemapNode(BinaryTreeNode<T> current, BinaryTreeNode<T> nextNode, BinaryTreeNode<T> nextNodeChild)
        {
            if (current.Left == nextNode)
            {
                current.Left = nextNodeChild;
            }
            else
            {
                current.Right = nextNodeChild;
            }
        }
    }
}
