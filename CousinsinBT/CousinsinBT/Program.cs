using System.Collections.Generic;
using MyTreeNode;

namespace MyTreeNode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

namespace CousinsinBT.Properties
{
    public class CousinsinBinaryTree
    {
        public bool IsCousins(TreeNode root, int x, int y)
        {
            Queue<(TreeNode node, TreeNode parent, int depth)> queue = new Queue<(TreeNode, TreeNode, int)>();
            queue.Enqueue((root, null, 0));

            TreeNode parentX = null, parentY = null;
            int depthX = -1;
            int depthY = -1;

            while (queue.Count > 0)
            {
                var (node, parent, depth) = queue.Dequeue();

                if (node.val == x)
                {
                    parentX = parent;
                    depthX = depth;
                }
                else if (node.val == y)
                {
                    parentY = parent;
                    depthY = depth;
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, node, depth + 1));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, node, depth + 1));
                }

                if (parentX != null && parentY != null)
                {
                    break;
                }
            }

            return depthX == depthY && parentX != parentY;
        }
        
        public static void Main(string[] args)
        { 
            TreeNode root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), null),
                new TreeNode(3)
            );

            CousinsinBinaryTree cousins = new CousinsinBinaryTree();
            bool result = cousins.IsCousins(root, 4, 3); 

            System.Console.WriteLine("Are they cousins? " + result);
        }
    }
}
