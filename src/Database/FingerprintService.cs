using System;
using SQLite;
using Algorithm;
using System.Collections.Concurrent;

namespace Database
{
    public class FingerprintService
    {
        private static SQLiteConnection _connection;
        private string thread_fingerprint;
        public double last_similarity;
        private double similarity_tolerance = 0;

        public static SQLiteConnection GetConnection()
        {
            return _connection;
        }
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

        //Basic beta non threading searcher
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

        //Giga chad multi threading
        private readonly object result_lock = new();
        public string threadedGetBerkasByAlgo(string berkasCitra, string algo)
        {
            var berkasCitraList = GetAllBerkasCitra();
            var Asciiinput = Algorithm.FingerprintConverter.ConvertToBinary(berkasCitra);
            string local_result = "";
            bool resultFound = false;

            //looper
            Parallel.ForEach(berkasCitraList, (sidik, state) =>
            {
                if (resultFound)
                {
                    state.Break();
                    return;
                }

                double percentage = 0;
                var berkas = localize_path(sidik.BerkasCitra);
                var Ascii = Algorithm.FingerprintConverter.ConvertToBinary(berkas);

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
                    lock (result_lock)
                    {
                        // Check kalo misalnya udah ada yang lain ketemu
                        if (!resultFound)
                        {
                            resultFound = true;
                            local_result = berkas;
                            state.Break(); // Stop further iterations
                        }
                    }
                }
            });

            if (!resultFound)
            {
                //wow threading
                double best_percentage = 0;
                Parallel.ForEach(berkasCitraList, (sidik) =>
                {
                    var berkas = localize_path(sidik.BerkasCitra);
                    var Ascii = Algorithm.FingerprintConverter.ConvertToBinary(berkas);

                    try
                    {
                        double percentage = Algorithm.Hamming.Similarity(Ascii, Asciiinput);

                        if (percentage >= similarity_tolerance)
                        {
                            //mutex
                            lock (result_lock)
                            {
                                if (percentage > best_percentage)
                                {
                                    best_percentage = percentage;
                                    local_result = berkas;
                                }
                            }
                        }
                    }
                    catch (Exception e) { 

                    }
                });
                last_similarity = best_percentage;
            }
            else
            {
                last_similarity = 100;
            }

            
            return local_result;
        }
    }
}