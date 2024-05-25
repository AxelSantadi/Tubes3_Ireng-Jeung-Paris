namespace SidikJariGUI
{

    public static class KMPAlgorithm
    {
        public static int Find(string key, string source)
        {

            int key_len = key.Length;
            int source_len = source.Length;

            //make lookup table;
            int[] table = new int[key_len];
            int i = 0;
            int j = 1;
            table[i] = 0;
            while (j < key_len)
            {
                if (key[j] == key[i])
                {
                    //set
                    table[j] = i + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (i > 0)
                    {
                        i = table[i - 1];
                    }
                    else
                    {
                        table[j] = 0;
                        j++;
                    }
                }
            }


            int find_progress = 0;
            i = 0;
            while (i < source_len && find_progress < key_len)
            {
                if (key[find_progress] == source[i])
                {
                    find_progress++;
                    i++;
                }
                else if (find_progress > 0)
                {
                    find_progress = table[find_progress - 1];
                }
                else
                {
                    i++;
                }
            }
            if (i < source_len) { return i - key_len; }
            else { return -1; }

        }
    }


}