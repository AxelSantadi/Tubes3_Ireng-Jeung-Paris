using System;

class BoyerMooreAlgorithm
{
    public static int[] ComputeLastOccurrenceArray(string pattern)
    {
        int[] lastOccurrence = new int[256]; // ukuran ASCII

        for (int i = 0; i < lastOccurrence.Length; i++)
        {
            lastOccurrence[i] = -1; // inisialisasi semua karakter dengan -1
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            lastOccurrence[(int)pattern[i]] = i;
        }

        return lastOccurrence;
    }

    public static double BoyerMooreSearch(string pattern, string text)
    {
        int patternLength = pattern.Length;
        int textLength = text.Length;

        if (patternLength == 0 || textLength == 0 || patternLength > textLength)
        {
            return 0; // jika pola kosong, teks kosong, atau panjang pola lebih besar dari panjang teks
        }

        int[] lastOccurrence = ComputeLastOccurrenceArray(pattern);
        int shift = 0;
        int matchCount = 0;

        while (shift <= textLength - patternLength)
        {
            int j = patternLength - 1;
            while (j >= 0 && pattern[j] == text[shift + j])
            {
                j--;
                matchCount++;
            }

            if (j < 0)
            {
                double percentage = (double)matchCount / patternLength * 100; // menghitung persentase kecocokan
                return percentage;
            }

            shift += Math.Max(1, j - lastOccurrence[(int)text[shift + j]]);
        }

        return 0; // jika tidak ada kecocokan, return 0
    }
}
