using System;
using SQLite;
using Algorithm;

namespace Database
{
    public class FingerprintService
    {
        private readonly SQLiteConnection _connection;
        public double last_similarity;

        public string localize_path(string path)
        {
            string cur_dir = @"..\..\..\..\Database";
            return Path.GetFullPath(Path.Combine(cur_dir, path));
        }
        public FingerprintService(string dbPath)
        {
            try
            {
                _connection = new SQLiteConnection(dbPath);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public FingerprintService(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public string GetNamaByBerkasCitra(string berkasCitra)
        {
            var query = $"SELECT Nama FROM SidikJari WHERE BerkasCitra = ?";
            var result = _connection.ExecuteScalar<string>(query, berkasCitra);

            return result;
        }

        public List<Biodata> GetBiodataByNama(string nama)
        {
            string query = $"SELECT * FROM Biodata WHERE Nama = ?";
            var biodatas = _connection.Query<Biodata>(query, nama);

            return biodatas;
        }

        public List<SidikJari> GetAllBerkasCitra()
        {
            string query = $"SELECT BerkasCitra FROM SidikJari";
            var berkasCitraList = _connection.Query<SidikJari>(query);
            return berkasCitraList;
        }

        public string getBerkascitrabyAlgo(string berkasCitra, string algo)
        {
            var berkasCitraList = GetAllBerkasCitra();
            var Asciiinput = Algorithm.FingerprintConverter.ConvertToBinary(berkasCitra);
            string result = "";
            last_similarity = 0;
            for (int i = 0; i < berkasCitraList.Count; i++)
            {
                var berkas = localize_path(berkasCitraList[i].BerkasCitra);
                var Ascii = Algorithm.FingerprintConverter.ConvertToBinary(berkas);
                double percentage = 0;
                if (algo == "BM")
                {
                    percentage = Algorithm.BoyerMooreAlgorithm.BoyerMooreSearch(Ascii, Asciiinput);
                }
                else if (algo == "KMP")
                {
                    percentage = Algorithm.KMPAlgorithm.KMPSearch(Ascii, Asciiinput);
                }
                if (percentage > 85)
                {
                    last_similarity = percentage;
                    return berkas;
                }
            }
            return result;
        }

    }
}