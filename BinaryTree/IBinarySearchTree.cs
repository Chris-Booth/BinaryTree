using System;

namespace BinaryTree
{
    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        BinaryTreeNode<T> Root { get; }
        bool InsertNode(T data);
        int GetLevel(BinaryTreeNode<T> binaryTreeNode, int current = 1);
        BinaryTreeNode<T> FindByValue(T data);
        bool RemoveNode(T data);
    }
}