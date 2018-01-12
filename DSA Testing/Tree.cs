using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Testing
{
    class Tree<T>
    {
        Tree<T> left;
        Tree<T> right;
        T data;

        public Tree(T data)
        {
            this.left = null;
            this.data = data;
            this.right = null;
        }

        public Tree(Tree<T> left, T data, Tree<T> right)
        {
            this.left = left;
            this.data = data;
            this.right = right;
        }

        public void preOrder() {
                Console.Write(this.data + " ");
                if(this.left != null)
                    this.left.preOrder();
                if (this.right != null)
                    this.right.preOrder();
        }

        public void preOrderIterative()
        {
                Stack<Tree<T>> s = new Stack<Tree<T>>();
                s.Push(this);
                while(s.Count != 0)
                {
                    var current = s.Pop();
                    while (current != null)
                    {
                        Console.Write(current.data + " " );
                        s.Push(current.right);
                        current = current.left;
                    }
                }
        }

        public void inOrder()
        {
            if (this.left != null)
                this.left.inOrder();
            Console.Write(this.data + " ");
            if (this.right != null)
                this.right.inOrderIterative();
        }

        public void inOrderIterative()
        {
            Stack<Tree<T>> s = new Stack<Tree<T>>();
            s.Push(this);
            while (s.Count != 0)
            {
                var current = s.Pop();
                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }
                Console.Write(current.data + " ");
                current = current.right;

            } 
        }

    }
}
