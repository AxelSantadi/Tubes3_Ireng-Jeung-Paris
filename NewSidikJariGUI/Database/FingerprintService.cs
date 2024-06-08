using System;
using SQLite;

public class FingerprintService
{
    private readonly SQLiteConnection _connection;

    public FingerprintService(string dbPath)
    {
        try{
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
        var Asciiinput = FingerprintConverter.ConvertToBinary(berkasCitra);
        string result = "";
        for (int i = 0; i < berkasCitraList.Count; i++)
        {
            var berkas = berkasCitraList[i].BerkasCitra;
            var Ascii = FingerprintConverter.ConvertToBinary(berkas);
            double percentage = 0;
            if (algo == "BM")
            {
                percentage = BoyerMooreAlgorithm.BoyerMooreSearch(Ascii, Asciiinput);
            }
            else if (algo == "KMP")
            {
                percentage = KMPAlgorithm.KMPSearch(Ascii, Asciiinput);
            }
            if (percentage > 85)
            {
                return berkas;
            }
        }
        return result;
    }

}