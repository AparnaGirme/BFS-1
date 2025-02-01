/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root == null)
        {
            return result;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        int level = 0;
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if (level == result.Count)
                {
                    result.Add(node.val);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
            }
            level++;
        }
        return result;
    }
}