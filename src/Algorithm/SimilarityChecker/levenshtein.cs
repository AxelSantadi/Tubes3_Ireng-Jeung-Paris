namespace Algorithm
{
    public class levenshtein
    {
        public static int LevenshteinDistance(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1]));
                    }
                }
            }

            return dp[m, n];
        }

        public static double Similarity(string s, string t)
        {
            int distance = LevenshteinDistance(s, t);
            return (1 - (double)distance / Math.Max(s.Length, t.Length)) * 100;
        }
    }
}