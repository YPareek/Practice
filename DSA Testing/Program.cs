using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DSA_Testing
{
    class Program
    {
        static void rotate(int[] arr, int n)
        {
            int x = arr[n - 1], i;
            for (i = n - 1; i > 0; i--)
                arr[i] = arr[i - 1];
            arr[0] = x;
        }

        static void Main(string[] args)
        {
            //int[][] matrix = new int[][] { new int[]{ 0,1,1,0,1}, new int[]{ 1,1,0,1,0} , new int[]{ 0,1,1,1,0}, new int[]{ 1,1,1,1,0}, new int[]{ 1,1,1,1,1}, new int[]{ 0,0,0,0,0} };
            //Console.WriteLine(maximizer(matrix));
            //var abc = new List<int>();
            //Console.ReadLine();

            //Creating a tree
            var myTree = new Tree<int>(
                new Tree<int>(new Tree<int>(4), 2, new Tree<int>(new Tree<int>(8),5, new Tree<int>(9))) ,
                1,
                new Tree<int>(new Tree<int>(6), 3, new Tree<int>(7)) );

            //// PreOrder Tree Traversal
            //myTree.preOrder();
            //Console.WriteLine();
            //myTree.preOrderIterative();

            // InOrder Tree Traversal
            myTree.inOrder();
            Console.WriteLine();
            myTree.inOrderIterative();



            Console.ReadLine();
        }

        static int maximizer(int[][] matrix) {
            int i = 0, j = 0, nRows = matrix.Length, nCols = matrix[0].Length;
            int[,] tempMatrix = new int[nRows, nCols];
            int maxOfTemp, maxi, maxj;

            for (i = 0; i < nRows; i++)
            {
                tempMatrix[i, 0] = matrix[i][0];
            }
            for (j = 0; j < nCols; j++)
            {
                tempMatrix[0, j] = matrix[0][j];
            }

            for (i = 1; i < nRows; i++)
            {
                for (j = 1; j < nCols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        tempMatrix[i, j] = Math.Min(tempMatrix[i, j - 1], Math.Min(tempMatrix[i - 1, j], tempMatrix[i - 1, j - 1])) + 1;

                    }
                    else
                    {
                        tempMatrix[i, j] = 0;
                    }
                }
            }

            maxOfTemp = tempMatrix[0, 0]; maxi = 0; maxj = 0;
            for (i = 0; i < nRows; i++)
            {
                for (j = 0; j < nCols; j++)
                {
                    if (maxOfTemp < tempMatrix[i, j])
                    {
                        maxOfTemp = tempMatrix[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }

            for (i = maxi; i > maxi - maxOfTemp; i--)
            {
                for (j = maxj; j > maxj - maxOfTemp; j--)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            return maxOfTemp;
        }
    }
}
