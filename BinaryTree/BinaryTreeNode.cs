using JetBrains.Annotations;
using System;

namespace BinaryTree
{
    [PublicAPI]
    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>>
        where T : IComparable<T>
    {
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Data { get; }

        public BinaryTreeNode(T data = default, BinaryTreeNode<T> left = default, BinaryTreeNode<T> right = default)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Data.CompareTo(other.Data);
        }

        public static bool operator <(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => left.CompareTo(right) < 0;
        public static bool operator >(BinaryTreeNode<T> left, BinaryTreeNode<T> right) => left.CompareTo(right) > 0;

        public override string ToString()
        {
            return $"{Data}";
        }
    }

    public static class BinaryTreeNode
    {
        public static BinaryTreeNode<T> CreateNode<T>(T data) where T : IComparable<T>
        {
            return new BinaryTreeNode<T>(data);
        }
    }
}
