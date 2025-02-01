public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (numCourses == 0 || prerequisites == null || prerequisites.Length == 0)
        {
            return true;
        }
        int[] totalCourses = new int[numCourses];
        Dictionary<int, List<int>> lookup = new Dictionary<int, List<int>>();
        for (int i = 0; i < numCourses; i++)
        {
            lookup.TryAdd(i, new List<int>());
        }
        for (int i = 0; i < prerequisites.Length; i++)
        {
            totalCourses[prerequisites[i][0]]++;
            lookup[prerequisites[i][1]].Add(prerequisites[i][0]);
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < totalCourses.Length; i++)
        {
            if (totalCourses[i] == 0)
            {
                queue.Enqueue(i);
                // totalCourses[i] = -1;
            }
        }
        if (queue.Count == 0)
        {
            return false;
        }
        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            var prereqs = lookup[course];
            foreach (var pr in prereqs)
            {
                totalCourses[pr]--;
                if (totalCourses[pr] == 0)
                {
                    queue.Enqueue(pr);
                }
            }
        }
        if (queue.Count > 0)
        {
            return false;
        }
        for (int i = 0; i < totalCourses.Length; i++)
        {
            if (totalCourses[i] > 0)
            {
                return false;
            }
        }
        return true;
    }
}