using System;

class KMPAlgorithm
{
    // Fungsi untuk membuat LPS Array
    public static int[] ComputeLPSArray(string pattern)
    {
        int M = pattern.Length;
        int[] lps = new int[M];
        int length = 0;
        int i = 1;

        lps[0] = 0; // lps[0] selalu 0

        // Loop untuk menghitung lps[i] untuk i = 1 hingga M-1
        while (i < M)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                lps[i] = length;
                i++;
            }
            else
            {
                if (length != 0)
                {
                    length = lps[length - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }

    // Fungsi untuk melakukan pencarian pola KMP
    public static double KMPSearch(string pattern, string text)
    {
        int M = pattern.Length;
        int N = text.Length;
        int[] lps = ComputeLPSArray(pattern);

        int i = 0; // indeks untuk text
        int j = 0; // indeks untuk pattern
        int matchCount = 0; // jumlah karakter yang cocok

        while (i < N)
        {
            if (pattern[j] == text[i])
            {
                i++;
                j++;
                matchCount++;
            }

            if (j == M)
            {
                double percentage = (double)matchCount / M * 100; // menghitung persentase kecocokan
                return percentage;
            }
            else if (i < N && pattern[j] != text[i])
            {
                if (j != 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }

        return 0; // jika tidak ada kecocokan, return 0
    }
}
